using System.Collections.Generic;

namespace AGL.Application.ViewModel
{
    public class GroupedPetResult
    {
        public GroupedPetResult()
        {
            GroupedPetVms = new HashSet<GroupedPetVm>();
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ICollection<GroupedPetVm> GroupedPetVms { get; set; }
    }
}
