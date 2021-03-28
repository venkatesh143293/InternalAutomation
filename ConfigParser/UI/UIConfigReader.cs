using System;
using WF.Test.AutomationFramework.ConfigParser.Core;
using WF.Test.AutomationFramework.ConfigParser.Enums;
using Microsoft.Extensions.Configuration;

namespace WF.Test.AutomationFramework.ConfigParser
{
    public sealed class UIConfigReader
    {
        public static void SetFrameworkSettings(string environmentType)
        {

            IConfigurationRoot testConfig = TestConfiguration.ReadTestConfiguration("appsettings.json");

            UIConfigSettings.AUT = testConfig[environmentType + ":aut"];

            UIConfigSettings.TestType = testConfig[environmentType + ":testType"];

            UIConfigSettings.IsLog = testConfig[environmentType + ":isLog"];

            //Settings.IsReporting = TestConfiguration.Settings.TestSettings["staging"].IsReadOnly;

            UIConfigSettings.ReportPath = testConfig[environmentType + ":reportPath"];

            UIConfigSettings.AppConnectionString = testConfig[environmentType + ":autConnectionString"];

            UIConfigSettings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), testConfig[environmentType + ":browser"]);

        }
    }
}
