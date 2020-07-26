using System.Collections.Generic;

namespace AGL.Application.ViewModel
{
    public class GroupedPetVm
    {
        //View model for represnting the grouped pets.
        public GroupedPetVm()
        {
            PetNames = new HashSet<string>();
        }
        public string Gender { get; set; }
        public ICollection<string> PetNames { get; set; }
    }
}
