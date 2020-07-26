using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Application.Dto;
using AGL.Application.Interfaces;
using AGL.Application.Validators;
using AGL.Application.ViewModel;

using log4net;

namespace AGL.Application.Services
{
    //Business logic of application
    public class PersonService : IPersonServices
    {
        private readonly IPersonRepository _personRepository;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PersonService));

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        //Get the list of  persons dto from the infrastructure layer. in this scenario our repository is a web service
        // which could be a database, file system in other cases.IRepository wrapp the data
        public async Task<List<PersonDto>> GetPersons()
        {
            var persons = await _personRepository.GetPersons();
            persons.ToList().ForEach(p => p.LogDate = DateTime.Now);
            return persons.ToList();
        }

        //Call the Web service and validate the result. if the result is not valid prepare the validation message.
        public async Task<GroupedPetResult> GetAsync(string petType)
        {
            var result = new GroupedPetResult();
            var persons = await GetPersons();
            if (persons != null)
            {
                var validator = new PersonListValidator();
                var validationResult = validator.Validate(persons);
                result.IsSuccess = validationResult.IsValid;

                if (validationResult.IsValid)
                {
                    result.Message = "";
                    result.GroupedPetVms = GroupPets(persons, petType);
                }
                else
                {
                    result.Message = string.Join("\n", validationResult.Errors.Select(x => $"{x.PropertyName}: Error: {x.ErrorMessage}"));
                    Logger.Error($"Validation Error:-{result.Message}");
                    result.IsSuccess = false;
                }
            }
            return result;
        }

        //Group the pets based on the gender for any pet name
        public List<GroupedPetVm> GroupPets(List<PersonDto> personDto, string petType)
        {
            return personDto?
                          .GroupBy(p => p.Gender)
                          .Select(vm => new GroupedPetVm
                          {
                              Gender = vm.Key,
                              PetNames = vm.SelectMany(p => p.Pets)
                                      .Where(pet => string.Compare(pet.Type, petType, StringComparison.CurrentCultureIgnoreCase) == 0)
                                      .OrderBy(q => q.Name)
                                      .Select(r => r.Name).ToList()
                          }).ToList();

        }
    }
}
