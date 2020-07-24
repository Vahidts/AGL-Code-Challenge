using System.Linq;
using AGL.Application.Common.Models;
using AGL.Infrastructure.Interfaces;

namespace AGL.Infrastructure.Context
{
    public class RepositoryContext : IContext
    {

        public IQueryable<PersonDto> Persons => throw new System.NotImplementedException();
    }
}
