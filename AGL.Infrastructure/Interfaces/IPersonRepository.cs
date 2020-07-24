
using System.Linq;
using System.Threading.Tasks;
using AGL.Application.Common.Models;
using AGL.Domain.Model;

namespace AGL.Infrastructure.Interfaces
{
   public interface IPersonRepository
    {
        Task<IQueryable<PersonDto>> GetPersons();
    }
}
