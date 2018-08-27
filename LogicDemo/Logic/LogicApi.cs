using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Threading.Tasks;

namespace LogicDemo.Logic
{
    public class LogicApi
    {
        public async Task<Guid> SendSmsAsync(string toPhoneNumber, string body)
        {
            var client = GetClient();

            var request = new SendSmsRequest
            {
                ToPhoneNumber = toPhoneNumber,
                Body = body
            };

            var response = await client.SendSmsAsync(Guid.Parse(Configuration.Current["LogicDemoSubscriptionId"]), Authorization.GenerateLogicAuthHeader(), LogicDemoApimSubscriptionKey, request).ConfigureAwait(false);

            return response.SmsMessageId;
        }

        public async Task<string> PingAsync()
        {
            var client = GetClient();

            var response = await client.PingAsync(LogicDemoApimSubscriptionKey).ConfigureAwait(false);

            return response.Version;
        }

        private ILogicService GetClient()
        {
            var clientSettings = new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            return RestService.For<ILogicService>(LogicDemoHost);
        }

        public string LogicDemoHost => Configuration.Current["LogicDemoHost"];
        public Guid LogicDemoSubscriptionId => Guid.Parse(Configuration.Current["LogicDemoSubscriptionId"]);
        public string LogicDemoApimSubscriptionKey => Configuration.Current["LogicDemoApimSubscriptionKey"];
    }
}
