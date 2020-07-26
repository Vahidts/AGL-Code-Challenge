using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using AGL.Application.Interfaces;
using AGL.Application.ViewModel;

namespace Agl.Presentation.UI.Presentation
{
    public class ShowGroupedPets : IShowGroupedPets
    {
        private readonly IPersonServices _psersonServices;

        public ShowGroupedPets(IPersonServices psersonServices)
        {
            _psersonServices = psersonServices;
        }

        //Format and Show the result in UI in desired format

        public async Task ShowAndFormatAsync(string petType)
        {
            Console.WriteLine("Getting result. Please wait...");

            GroupedPetResult result = await _psersonServices.GetAsync(petType);
            Console.Clear();

            if (result != null && result.IsSuccess && result.GroupedPetVms.Any())
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                foreach (var pet in result.GroupedPetVms)
                {
                    if (pet.PetNames.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(pet.Gender);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        foreach (var name in pet.PetNames)
                        {
                            Console.WriteLine($"\t • {name}", Color.Magenta);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"It seems that {pet.Gender}s people does not have this type of pet :( ");
                    }
                }
            }
            else
            {
                Console.WriteLine("?It seems there is no result available :( ");
            }
        }
    }
}
