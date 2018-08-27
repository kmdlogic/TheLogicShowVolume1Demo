using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicDemo.Yammer
{
    class YammerApi
    {
        public async Task<YammerMessage> GetMessageAsync(int id)
        {
            var client = GetClient();

            var response = await client.GetMessage(Authorization.GenerateYammerAuthHeader(), id).ConfigureAwait(false);

            return response;
        }

        private IYammerService GetClient()
        {
            var clientSettings = new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            return RestService.For<IYammerService>("https://www.yammer.com");
        }
    }
}