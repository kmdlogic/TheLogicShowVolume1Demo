using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogicDemo
{
    class Configuration
    {
        public readonly static IConfigurationRoot Current;

        private Configuration() { }

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Current = builder.Build();            
        }
    }
}
