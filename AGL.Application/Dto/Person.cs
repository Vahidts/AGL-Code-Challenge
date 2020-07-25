using System;

using AGL.Domain.Model;

namespace AGL.Application.Dto
{
    //DTO Object for Application layer
    public class PersonDto : Person
    {
        public DateTime LogDate { get; set; }
    }
}
