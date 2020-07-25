using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using AGL.Application.Dto;
using AGL.Application.Interfaces;

using log4net;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace AGL.Infrastructure.Context
{
    public class Context : IContext
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Context));
        private readonly IConfiguration _config;

        public Context(IConfiguration config)
        {
            _config = config;
        }

        //Get grouped person data from the webservice
        public async Task<IQueryable<PersonDto>> GetPersonsFromWebService()
        {
            var baseUrl = _config.GetSection("WebSettings").GetSection("WebServiceBaseUrl").Value;
            var objectName = _config.GetSection("WebSettings").GetSection("JsonObject").Value;
            Logger.Info("Call web service");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}/{objectName}"))
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Logger.Info("Web service Result backed.");
                    return string.IsNullOrEmpty(jsonString) ? null : JsonConvert.DeserializeObject<List<PersonDto>>(jsonString)?.AsQueryable();
                }
            }
        }
    }
}