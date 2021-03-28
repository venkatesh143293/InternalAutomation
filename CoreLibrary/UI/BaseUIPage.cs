using System;
using WF.Test.AutomationFramework.ConfigParser;
using WF.Test.AutomationFramework.ConfigParser.Enums;
using WF.Test.AutomationFramework.CoreLibraryInterfaces;
using WF.Test.AutomationFramework.Enums;
using WF.Test.AutomationFramework.Helpers;
using OpenQA.Selenium;

namespace WF.Test.AutomationFramework.CoreLibrary.UI
{
    public class BaseUIPage 
    {
        public virtual BrowserType BrowserType { get; set; }

        public virtual IBaseUIPage CurrentPage { get; set; }

        public static IWebDriver WebDriver { get; set; }


        /// <summary>
        /// Navigate to a URL
        /// </summary>
        public virtual void NavigateSite()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Navigate().GoToUrl(UIConfigSettings.AUT);
            WebDriver.Manage().Window.Maximize();
            Reporter.LogPass("Navigated to URL :" + UIConfigSettings.AUT.ToString());
        }


        /// <summary>
        /// Initializing all UI  Settings
        /// </summary>
        public void InitializeSettings(EnvironmentType environment)
        {
            //Set all the settings for framework
            UIConfigReader.SetFrameworkSettings(environment.ToString());
        }


        protected TPage GetInstance<TPage>() where TPage : BaseUIPage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BaseUIPage
        {
            return (TPage)this;
        }
    }
}
