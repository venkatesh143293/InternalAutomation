using System.Data.SqlClient;
using WF.Test.AutomationFramework.ConfigParser.Enums;

namespace WF.Test.AutomationFramework.ConfigParser
{
    public sealed class UIConfigSettings
    {
        public static int Timeout { get; set; }

        public static string IsReporting { get; set; }

        public static string TestType { get; set; }

        public static string AUT { get; set; }

        public static string BuildName { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static SqlConnection ApplicationCon { get; set; }

        public static string AppConnectionString { get; set; }

        public static string IsLog { get; set; }

        public static string ReportPath { get; set; }

        public static bool FileCreated { get; set; }
    }
}
