using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using WF.Test.AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WF.Test.AutomationFramework.CoreLibrary.UI.Extensions
{
    public static class DriverExtensions
    {

        /// <summary>
        /// Waiting until the page loads
        /// </summary>
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript(Driver._ReturnDocReadyState).ToString();
                return state.Equals(Driver._Complete);
            },
                                   10);
        }

        /// <summary>
        /// Waiting until ajax loads
        /// </summary>
        public static void WaitForAjax(this IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0");
                return isAjaxFinished;
            });
        }

        /// Wait for condition to meet
        private static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Finding element by ID
        /// </summary>
        public static IWebElement FindById(this IWebDriver driver, string element)
        {
            try
            {
                if (driver.FindElement(By.Id(element)).Displayed)
                {
                    return driver.FindElement(By.Id(element));
                }
            }
            catch (Exception e)
            {
              //  Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
            }
            return null;
        }


        /// <summary>
        /// Finding element by Xpath
        /// </summary>
        public static IWebElement FindByXpath(this IWebDriver driver, string element)
        {
            try
            {
                if (driver.FindElement(By.XPath(element)).Displayed)
                {
                    return driver.FindElement(By.XPath(element));
                }
            }
            catch (Exception e)
            {
                //  Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
            }
            return null;
            
        }

        /// <summary>
        /// Finding element by CssSelector
        /// </summary>
        public static IWebElement FindByCssSelector(this IWebDriver driver, string element)
        {
            try
            {
                if (driver.FindElement(By.CssSelector(element)).Displayed)
                {
                    return driver.FindElement(By.CssSelector(element));
                }
            }
            catch (Exception e)
            {
                //Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
            }
            return null;
        }

        /// <summary>
        /// Finding element by TagName
        /// </summary>
        public static IWebElement FindByTagName(this IWebDriver driver, string element)
        {
            try
            {
                if (driver.FindElement(By.TagName(element)).Displayed)
                {
                    return driver.FindElement(By.TagName(element));
                }
            }
            catch (Exception e)
            {
             //   Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
            }
            return null;
        }


        /// <summary>
        /// Finding element by LinkText
        /// </summary>
        public static IWebElement FindByLinkText(this IWebDriver driver, string element)
        {
            try
            {
                if (driver.FindElement(By.LinkText(element)).Displayed)
                {
                    return driver.FindElement(By.LinkText(element));
                }
            }
            catch (Exception e)
            {
             //  Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
            }
            return null;
        }

        /// <summary>
        /// Finding element by Partial LinkText
        /// </summary>
        public static IWebElement FindByPartialLinkText(this IWebDriver driver, string element)
        {
            try
            {
                if (driver.FindElement(By.PartialLinkText(element)).Displayed)
                {
                    return driver.FindElement(By.PartialLinkText(element));
                }
            }
            catch (Exception e)
            {
             //   Reporter.LogFailWithScreenshot("Element Not found : {element} " + e.Message);
            }
            return null;
        }

        /// <summary>
        /// Finding Multi object element using Xpath
        /// </summary>
        public static IList<IWebElement> MultiObjFindByXpath(this IWebDriver driver, string element)
        {
            try
            {
                return driver.FindElements(By.XPath(element));
            }
            catch (Exception e)
            {
               // Reporter.LogFailWithScreenshot("Elements Not found : {element} " + e.Message);
            }
            return null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static DefaultWait<IWebDriver> FluentWait(this IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void WaitforElement(this IWebDriver driver, string element)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(By.XPath(element)));
            }
            catch (Exception ex)
            {

                Reporter.LogFail(ex.InnerException.ToString());
            }
            
        }

        public static void LoadingWait(this IWebDriver driver, string element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(element))); // wait for loader to appear
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(element))); // wait for loader to disappear
        }

    }

}
