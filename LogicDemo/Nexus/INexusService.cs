using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicDemo.Nexus
{
    public interface INexusService
    {
        [Get("/nexus/v1/patients?filterId={id}&pageSize={pageSize}")]
        Task<NexusPatientFilter> FilterPatients([Header("Ocp-Apim-Subscription-Key")] string apimSubscriptionKey, [Header("Authorization")] string authorization, int id, int pageSize = 50);

        [Get("/nexus/v1/patients?ids={ids}")]
        Task<List<NexusPatient>> GetPatients([Header("Ocp-Apim-Subscription-Key")] string apimSubscriptionKey, [Header("Authorization")] string authorization, string ids);

        [Get("/nexus/v1/preferences/CITIZEN_LIST")]
        Task<List<NexusCitizen>> GetCitizens([Header("Ocp-Apim-Subscription-Key")] string apimSubscriptionKey, [Header("Authorization")] string authorization);

        [Get("/nexus/v1/preferences/CITIZEN_LIST/{id}")]
        Task<NexusCitizen> GetCitizen([Header("Ocp-Apim-Subscription-Key")] string apimSubscriptionKey, [Header("Authorization")] string authorization, int id);
    }
}
