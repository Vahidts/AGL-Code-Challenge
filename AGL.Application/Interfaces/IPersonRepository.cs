using System.Linq;
using System.Threading.Tasks;
using AGL.Application.Dto;

namespace AGL.Application.Interfaces
{
    //Interface for Repository in Core that will be used in InfraStructure/Data/Pesistent layer
    public interface IPersonRepository
    {
        Task<IQueryable<PersonDto>> GetPersons();
    }
}
