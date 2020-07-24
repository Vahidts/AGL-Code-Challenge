using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGL.Application.Common.Models;

namespace AGL.Infrastructure.Interfaces
{
    public interface IContext
    {
        public IQueryable<PersonDto> Persons { get; }
    }
}
