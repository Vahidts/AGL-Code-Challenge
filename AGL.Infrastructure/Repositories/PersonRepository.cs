using System.Linq;
using System.Threading.Tasks;
using AGL.Application.Dto;
using AGL.Application.Interfaces;


namespace AGL.Infrastructure.Repositories
{
    //Implementation of Repository when data comes from web service 
    public class PersonRepository : IPersonRepository
    {
        private readonly IContext context;

        public PersonRepository(IContext Context)
        {
            context = Context;
        }

        public async Task<IQueryable<PersonDto>> GetPersons()
        {
            return await context.GetPersonsFromWebService();
        }
    }
}
