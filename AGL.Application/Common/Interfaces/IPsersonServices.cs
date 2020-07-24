using System.Collections.Generic;
using System.Threading.Tasks;
using AGL.Application.Common.Models;
using AGL.Application.ViewModel;

namespace AGL.Application.Common.Interfaces
{
    public interface IPersonServices
    {
        Task<List<PersonDto>> GetPersons();
        Task<GroupedPetResult> GetAsync();
        List<GroupedPetVm> GroupPets(List<PersonDto> personDto);
    }
}
