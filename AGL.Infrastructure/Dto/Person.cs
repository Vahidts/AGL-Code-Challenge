using System;
using AGL.Domain.Model;

namespace AGL.Application.Common.Models
{
    public class PersonDto : Person
    {
        public DateTime LogDate { get; set; }
    }
}
