using WF.Test.AutomationFramework.CoreLibrary.UI.Extensions;
using WF.Test.AutomationFramework.Helpers;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WF.Test.AutomationFramework.CoreLibrary.UI
{
    public static class UIHelper
    {

        /// <summary>
        /// Checking errors on a page
        /// </summary>
        public static void CheckErrorsOnPage(this IWebDriver webDriver)
        {
            if (IsErrorOnPage(webDriver))
            {
                Reporter.LogFailWithScreenshot("Error on Page : " + webDriver.Title +
                    "<br /> URL : " + webDriver.Url);
            }
            else
            {
                Reporter.LogPass("Successfully loaded Page : " + webDriver.Title +
                    "<br />  URL : " + webDriver.Url);
            }
        }

        /// <summary>
        /// Is errors on a page, returns Boolean
        /// </summary>
        public static bool IsErrorOnPage(this IWebDriver webDriver)
        {

            List<string> errors = new List<string>();
            errors.Add("Error");
            errors.Add("Object reference not set to an instance of an object");
            errors.Add("Page Not Found");
            errors.Add("This site can’t be reached");
            errors.Add("404 - File or directory not found");

            string pageBody = webDriver.FindElement(By.TagName("body")).Text;
            if (errors.Any(x => pageBody.Contains(x)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Skip Privacy Alert Page
        /// </summary>
        public static void SkipPrivacyAlertPage(this IWebDriver webDriver)
        {
            string pageBody = webDriver.FindElement(By.TagName("body")).Text;
            if (pageBody.Contains("Your connection is not private"))
            {

                IWebElement btnAdvanced = webDriver.FindById("details-button");
                btnAdvanced.Click();
                Reporter.LogInfo("Clicking on Details button to skip Privacy Alert Page");
                IWebElement lnkProceed = webDriver.FindById("proceed-link");
                lnkProceed.Click();
                Reporter.LogInfo("Clicking on Procced link to skip Privacy Alert Page");
            }
        }

        /// <summary>
        /// Navigate to a URL provided
        /// </summary>
        public static void GoToURL(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            Reporter.LogPass("Navigating to Page : " + webDriver.Title +
                    "<br />  URL : " + webDriver.Url);
        }

        /// <summary>
        /// Navigate to all the links on client Home page 
        /// </summary>
        public static void NavigateToAllLinksInPage(this IWebDriver webDriver, string pageName, List<string> exclusions)
        {
            // Read all the links 
            var links = webDriver.FindElements(By.XPath("//*[@href]"));

            //Navigate to all the links on client Home page 
            //   Do not Navigate to links in exlusion list
            //   Click a URL
            //   Check errors on the page
            //   Navigate back to User Homepage
            //   Click the next and continue aboce stepss
            string currentUrl = webDriver.Url.ToString();
            exclusions.Add(currentUrl);

            string navigateURL;
            Reporter.LogInfo("Navigating to all Links on Page : " + pageName);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            for (int i = 0; i < links.Count; i++)
            {
                
                navigateURL = links[i].GetAttribute("href");
                // Do not Navigate of its in the exclusion list.
                if (!exclusions.Any(x => navigateURL.Contains(x)))
                {
                    // /Navigate to a link on client Home page
                    webDriver.performNavigation(navigateURL);
                    // Check for errors on the page
                    webDriver.CheckErrorsOnPage();

                    // Navigate back to User Home page
                    webDriver.performNavigation(currentUrl);

                    // Read all the links 
                    links = webDriver.FindElements(By.XPath("//*[@href]"));
                }
            }

        }

        private static void performNavigation(this IWebDriver webDriver, string navigateURL)
        {
            // /Navigate to a link on client Home page
            webDriver.GoToURL(navigateURL);
            webDriver.WaitForPageLoaded();
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
