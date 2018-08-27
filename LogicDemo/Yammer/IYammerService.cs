using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicDemo.Yammer
{
    public interface IYammerService
    {
        [Get("/api/v1/messages/{id}.json")]
        Task<YammerMessage> GetMessage([Header("Authorization")] string authorization, int id);
    }
}
