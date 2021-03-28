using System.Configuration;

namespace WF.Test.AutomationFramework.ConfigParser.CoreNetFramework
{
    public class FrameworkElement : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string)base["name"];

        [ConfigurationProperty("aut", IsRequired = true)]
        public string AUT => (string)base["aut"];

        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser => (string)base["browser"];

        [ConfigurationProperty("testType", IsRequired = true)]
        public string TestType => (string)base["testType"];

        [ConfigurationProperty("isLog", IsRequired = true)]
        public string IsLog => (string)base["isLog"];

        [ConfigurationProperty("reportPath", IsRequired = true)]
        public string ReportPath => (string)base["reportPath"];

        [ConfigurationProperty("autConnectionString", IsRequired = true)]
        public string AUTDBConnectionString => (string)base["autConnectionString"];
    }
}
