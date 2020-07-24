using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AGL.Application.Common.Models;
using AGL.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AGL.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IConfiguration _config;

        public PersonRepository(IConfiguration config)
        {
            _config = config;

        }
        public async Task<IQueryable<PersonDto>> GetPersons()
        {
            try
            {
                var baseUrl = _config.GetSection("WebSettings").GetSection("WebServiceBaseUrl").Value;
                var objectName = _config.GetSection("WebSettings").GetSection("JsonObject").Value;

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{baseUrl}/{objectName}"))
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return string.IsNullOrEmpty(jsonString) ? null : JsonConvert.DeserializeObject<List<PersonDto>>(jsonString)?.AsQueryable();
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
