using System.Collections.Generic;

namespace AGL.Domain.Model
{
    public class Person
    {
        public Person()
        {
            Pets = new HashSet<Pet>();
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public ICollection<Pet> Pets { get; private set; }
    }
}
