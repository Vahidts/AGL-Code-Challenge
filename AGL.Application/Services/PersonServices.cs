using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Application.Common.Interfaces;
using AGL.Application.Common.Models;
using AGL.Application.Validators;
using AGL.Application.ViewModel;
using AGL.Infrastructure.Interfaces;
using Polly;

namespace AGL.Application.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _personRepository;


        public PersonServices(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<PersonDto>> GetPersons()
        {
            var persons = await _personRepository.GetPersons();
            return persons.ToList();
        }

        public async Task<GroupedPetResult> GetAsync()
        {
            var result = new GroupedPetResult();

            try
            {
                var persons = await GetPersons();
                if (persons != null)
                {
                    var validator = new PersonListValidator();
                    var validationResult = validator.Validate(persons);
                    result.IsSuccess = validationResult.IsValid;

                    if (validationResult.IsValid)
                    {
                        result.Message = "";
                        result.GroupedPetVms = GroupPets(persons);
                    }
                    else
                    {
                        result.Message = string.Join("\n", validationResult.Errors.Select(x => $"{x.PropertyName}: Error: {x.ErrorMessage}"));
                        result.IsSuccess = false;
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                result.Message = "Something went wrong.Check the log for details.";
                result.IsSuccess = false;
                return result;
            }
        }

        public List<GroupedPetVm> GroupPets(List<PersonDto> personDto)
        {
            return personDto?
                          .GroupBy(p => p.Gender)
                          .Select(vm => new GroupedPetVm
                          {
                              Gender = vm.Key,
                              PetName = vm.SelectMany(p => p.Pets)
                                      .Where(pet => string.Compare(pet.Type, "cat", StringComparison.CurrentCultureIgnoreCase) == 0)
                                      .OrderBy(q => q.Name)
                                      .Select(r => r.Name).ToList()
                          }).ToList();

        }
    }
}
