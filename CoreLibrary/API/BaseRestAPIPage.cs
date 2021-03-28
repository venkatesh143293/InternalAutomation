using WF.Test.AutomationFramework.ConfigParser;
using WF.Test.AutomationFramework.Enums;

namespace WF.Test.AutomationFramework.CoreLibrary.API
{
    public class BaseRestAPIPage
    {
      

        /// <summary>
        /// Initializing all UI  Settings
        /// </summary>
        public void InitializeAPISettings(EnvironmentType environment)
        {
            //Set all the settings for framework
            APIConfigReader.SetFrameworkSettings(environment.ToString());
        }

    }
}
