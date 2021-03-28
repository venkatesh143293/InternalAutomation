using System;
using WF.Test.AutomationFramework.ConfigParser.Core;
using WF.Test.AutomationFramework.ConfigParser.Enums;
using Microsoft.Extensions.Configuration;

namespace WF.Test.AutomationFramework.ConfigParser
{
    public sealed class APIConfigReader
    {
        public static void SetFrameworkSettings(string environmentType)
        {

            IConfigurationRoot testConfig = TestConfiguration.ReadTestConfiguration("apisettings.json");

            APIConfigSettings.BaseURI = testConfig[environmentType + ":baseURI"];

            APIConfigSettings.ParameterName = testConfig[environmentType + ":parameterName"];

            APIConfigSettings.ParameterValue = testConfig[environmentType + ":parameterValue"];

            APIConfigSettings.SecondaryURI = testConfig[environmentType + ":secondaryURI"];
            
            APIConfigSettings.TestType = testConfig[environmentType + ":testType"];

            APIConfigSettings.IsLog = testConfig[environmentType + ":isLog"];

            APIConfigSettings.ReportPath = testConfig[environmentType + ":reportPath"];

            APIConfigSettings.SqlConnectionString = testConfig[environmentType + ":sqlConnectionString"];
        }
    }
}
