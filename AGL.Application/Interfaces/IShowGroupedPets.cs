using System.Threading.Tasks;

namespace AGL.Application.Interfaces
{
    //Interface for show the grouped pets in UI.
    public interface IShowGroupedPets
    {
        Task ShowAndFormatAsync(string petType);
    }
}