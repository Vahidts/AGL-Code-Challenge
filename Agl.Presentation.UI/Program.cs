using System;
using AGL.Infrastructure.Interfaces;
using AGL.Application.Common.Interfaces;
using AGL.Application.Services;
using AGL.Infrastructure.Context;
using AGL.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Agl.Presentation.UI;
using System.Threading.Tasks;

namespace AGL_Code_Challenge
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static async Task Main(string[] args)
        {

            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            var t = await scope.ServiceProvider.GetRequiredService<IShowGroupedPets>().ShowAsync();

            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();

            IConfiguration config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", false, true)
                 .Build();

            services.AddMvc(setup =>
            {
            }).AddFluentValidation();

            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<IContext, RepositoryContext>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IPersonServices, PersonServices>();
            services.AddSingleton<IShowGroupedPets, ShowGroupedPets>();
            _serviceProvider = services.BuildServiceProvider(true);

        }
    }
}
