using System.Threading.Tasks;
using AGL.Application.Common.Interfaces;
using AGL.Application.ViewModel;

namespace Agl.Presentation.UI
{
   public class ShowGroupedPets : IShowGroupedPets
    {
        private readonly IPersonServices _psersonServices;

        public ShowGroupedPets(IPersonServices psersonServices)
        {
            _psersonServices = psersonServices;
        }

        public async Task<GroupedPetResult> ShowAsync()
        {
            GroupedPetResult person   = await _psersonServices.GetAsync();
            return person;
        }
    }
}
