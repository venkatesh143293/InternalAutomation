using System.Configuration;


namespace WF.Test.AutomationFramework.ConfigParser.CoreNetFramework
{
    public class DepricatedTestConfiguration : ConfigurationSection
    {

        public static DepricatedTestConfiguration Settings => (DepricatedTestConfiguration)ConfigurationManager.GetSection("TestConfiguration");

        [ConfigurationProperty("testSettings")]
        public FrameworkElementCollection TestSettings => (FrameworkElementCollection)base["testSettings"];
    }
}
