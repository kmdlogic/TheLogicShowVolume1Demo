using Refit;
using System;
using System.Threading.Tasks;

namespace LogicDemo.Logic
{
    public interface ILogicService
    {
        [Get("/logic/v1/api/v1/ping")]
        Task<PingResponse> PingAsync([Header("Ocp-Apim-Subscription-Key")] string apimSubscriptionKey);

        [Post("/logic/v1/api/v1/subscriptions/{subscriptionId}/sms")]
        Task<SendSmsResponse> SendSmsAsync(Guid subscriptionId, [Header("Authorization")] string authorization, [Header("Ocp-Apim-Subscription-Key")] string apimSubscriptionKey, [Body] SendSmsRequest sendSmsRequest);
    }
}
