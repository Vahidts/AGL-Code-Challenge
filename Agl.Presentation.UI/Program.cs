using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Agl.Presentation.UI.Presentation;

using AGL.Application.Interfaces;
using AGL.Application.Services;
using AGL.Infrastructure.Context;
using AGL.Infrastructure.Repositories;

using FluentValidation.AspNetCore;

using log4net;
using log4net.Config;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGL_Code_Challenge
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        static async Task Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter Pet type");
                    return;
                }
                string petType = args[0];

                RegisterServices();


                await _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IShowGroupedPets>().ShowAsync(petType);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.Check the log for details.");
                Logger.Error($"Exception :{ex.Message} - Inner exception: {ex?.InnerException?.Message}");
                Console.ReadLine();
            }
        }

        //Register Services for Dependency Injections.

        private static void RegisterServices()
        {

            IServiceCollection services = new ServiceCollection();

            IConfiguration config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", false, true)
                 .Build();

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


            services.AddMvc(setup =>
            {
            }).AddFluentValidation();

            services.AddSingleton(config);
            services.AddTransient<IContext, Context>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonServices, PersonService>();
            services.AddTransient<IShowGroupedPets, ShowGroupedPets>();



            _serviceProvider = services.BuildServiceProvider(true);

        }
    }
}
