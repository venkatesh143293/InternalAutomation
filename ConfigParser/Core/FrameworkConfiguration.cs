using Microsoft.Extensions.Configuration;
using System.IO;

namespace WF.Test.AutomationFramework.ConfigParser.Core
{
    class TestConfiguration
    {
        public static IConfigurationRoot ReadTestConfiguration(string settingsFile)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(settingsFile, optional: true, reloadOnChange: true);
           return builder.Build();
        }

  
    }
}
