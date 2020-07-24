using System.Collections.Generic;

namespace AGL.Application.ViewModel
{
    public class GroupedPetVm
    {
        public GroupedPetVm()
        {
            PetName = new HashSet<string>();
        }
        public string Gender { get; set; }
        public ICollection<string> PetName { get; set; }
    }
}
