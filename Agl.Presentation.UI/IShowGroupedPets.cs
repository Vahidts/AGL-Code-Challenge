using System.Threading.Tasks;
using AGL.Application.ViewModel;

namespace Agl.Presentation.UI
{
    public interface IShowGroupedPets
    {
        Task<GroupedPetResult> ShowAsync();
    }
}