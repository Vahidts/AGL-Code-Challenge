using System.Collections.Generic;
using System.Threading.Tasks;

using AGL.Application.Dto;
using AGL.Application.ViewModel;

namespace AGL.Application.Interfaces
{
    //Interface for Person Service which has the business logic of application
    public interface IPersonServices
    {
        Task<List<PersonDto>> GetPersons();
        Task<GroupedPetResult> GetAsync(string petType);
        List<GroupedPetVm> GroupPets(List<PersonDto> personDto, string petType);
    }
}
