using System;
using System.Collections.Generic;
using System.Text;

namespace LogicDemo
{
    class Authorization
    {
        public static string GenerateLogicAuthHeader()
        {
            var jwtToken = Configuration.Current["LogicDemoJwtToken"];
            return string.IsNullOrEmpty(jwtToken) ? string.Empty : $"Bearer {jwtToken}";
        }

        public static string GenerateNexusAuthHeader()
        {
            var jwtToken = Configuration.Current["NexusDemoJwtToken"];
            return string.IsNullOrEmpty(jwtToken) ? string.Empty : $"Bearer {jwtToken}";
        }

        internal static string GenerateYammerAuthHeader()
        {
            var jwtToken = Configuration.Current["YammerBearer"];
            return string.IsNullOrEmpty(jwtToken) ? string.Empty : $"Bearer {jwtToken}";
        }
    }
}
