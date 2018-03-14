using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore
{
    public static class WebConfig
    {
        private static IConfigurationRoot _config;

        static WebConfig()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("webConfig.json");

            _config = builder.Build();
        }

        public static string NorthwindConnectionString
        {
            get
            {
                return _config["NorthwindConnectionString"];
            }
        }

    }
}
