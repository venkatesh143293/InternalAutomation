using OpenQA.Selenium;
using System;
using System.Threading;

namespace WF.Test.AutomationFramework.Helpers
{
    public static class WebPageHelpers
    {

        /// <summary>
        /// Wait for page url to change
        /// </summary>
        public static void WaitForPageChange(this IWebDriver driver)
        {
            string currentUrl = driver.Url.ToString();
            do
            {
                Thread.Sleep(4000);
            } while (driver.Url.ToString() == currentUrl);
        }

        /// <summary>
        /// Verify Page Title
        /// </summary>
        public static void VerifyPageTitle(this IWebDriver driver, string expectedPageTitle)
        {
            string pageTitle = GetTitle(driver);
            TextCompareHelper.VerifyText("Page Title", expectedPageTitle, pageTitle);
        }

        /// <summary>
        /// Getting Page Title
        /// </summary>
        public static string GetTitle(this IWebDriver driver)

        {
            try
            {
                return driver.Title;

            }
            catch (Exception e)
            {
                Reporter.LogFailWithScreenshot("Not able to Retrieve Page Title " + e.Message);
            }
            return null;
        }


    }
}
