using WF.Test.AutomationFramework.ConfigParser.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WF.Test.AutomationFramework.CoreLibrary.UI
{
    public class Driver : BaseUIPage
    {
        public const string _Complete = "complete";
        public const string _ReturnDocReadyState = "return document.readyState";

        public Driver()
        {
            BrowserType = BrowserType.None;
        }

        //public Driver(BrowserType browserType)
        //{
        //    BrowserType = browserType;
        //    InitBrowser();
        //}


        /// Initializing Browser
        public void InitBrowser()
        {
            switch (BrowserType)
            {
                case BrowserType.InternetExplorer:
                    WebDriver = new InternetExplorerDriver();
                    break;
                case BrowserType.FireFox:
                    WebDriver = new FirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    WebDriver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    WebDriver = new EdgeDriver();
                    break;
            }
        }
    }
}
