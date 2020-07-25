using System.Linq;
using System.Threading.Tasks;

using AGL.Application.Dto;

namespace AGL.Application.Interfaces
{
    //Interface Context for that implemented in Infrastructre layer
    public interface IContext
    {
        public Task<IQueryable<PersonDto>> GetPersonsFromWebService();
    }
}
