using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicDemo.Nexus
{
    class NexusApi
    {
        public async Task<List<NexusCitizen>> GetCitizensAsync()
        {
            var client = GetClient();

            var response = await client.GetCitizens(NexusDemoApimSubscriptionKey, Authorization.GenerateNexusAuthHeader()).ConfigureAwait(false);

            return response;
        }

        public async Task<NexusCitizen> GetCitizenAsync(int id)
        {
            var client = GetClient();

            var response = await client.GetCitizen(NexusDemoApimSubscriptionKey, Authorization.GenerateNexusAuthHeader(), id).ConfigureAwait(false);

            return response;
        }

        public async Task<NexusPatientFilter> FilterPatientsAsync(int filterId, int pageSize = 50)
        {
            var client = GetClient();

            var response = await client.FilterPatients(NexusDemoApimSubscriptionKey, Authorization.GenerateNexusAuthHeader(), filterId, pageSize).ConfigureAwait(false);

            return response;
        }

        public async Task<List<NexusPatient>> GetPatients(string idList)
        {
            var client = GetClient();

            var response = await client.GetPatients(NexusDemoApimSubscriptionKey, Authorization.GenerateNexusAuthHeader(), idList).ConfigureAwait(false);

            return response;
        }

        private INexusService GetClient()
        {
            var clientSettings = new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            return RestService.For<INexusService>(NexusDemoHost);
        }

        public string NexusDemoHost => Configuration.Current["NexusDemoHost"];
        public string NexusDemoApimSubscriptionKey => Configuration.Current["NexusDemoApimSubscriptionKey"];
    }
}