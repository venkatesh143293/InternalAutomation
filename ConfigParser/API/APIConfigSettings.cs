using System.Data.SqlClient;
using WF.Test.AutomationFramework.ConfigParser.Enums;

namespace WF.Test.AutomationFramework.ConfigParser
{
    public sealed class APIConfigSettings
    {
        public static int Timeout { get; set; }

        public static string IsReporting { get; set; }

        public static string TestType { get; set; }

        public static string BaseURI { get; set; }

        public static string ParameterName { get; set; }

        public static string ParameterValue { get; set; }

        public static string BuildName { get; set; }

        public static string SecondaryURI { get; set; }

       public static string SqlConnectionString { get; set; }

        public static string IsLog { get; set; }

        public static string ReportPath { get; set; }
    }
}
