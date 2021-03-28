using WF.Test.AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace WF.Test.AutomationFramework.CoreLibrary.UI.Extensions
{
    public static class WebElementExtension
    {

        /// <summary>
        /// Method to enter Text(text) in a text field (elementName)
        /// </summary>
        public static void SetText(this IWebDriver driver, By by, string elementName, string text)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).SendKeys(text);
                Reporter.LogPass("Inserted Text in field : " + elementName + " with text :  " + text);
            }
            catch (Exception)
            {

                Reporter.LogFail(" Failed to insert Text in field : " + elementName + " with text :  " + text);
            }

        }

        /// <summary>
        /// Method to enter Text(text) in a text field 
        /// </summary>
        public static void SetText(this IWebDriver driver, By by, string text)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).SendKeys(text);
                Reporter.LogPass("Inserted Text in field : " +by.ToString() + " with text :  " + text);
            }
            catch (Exception)
            {

                Reporter.LogFail(" Failed to insert Text in field : " +by.ToString() + " with text :  " + text);

            }

        }

        /// <summary>
        /// Method to enter Text(text) in a text field 
        /// </summary>
        public static void SetSecureText(this IWebDriver driver, By by, string text)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));//.SendKeys(text);
                IWebElement Password() => element;
                Password().SendKeys(text);
                Reporter.LogPass("Inserted Text in field : " +by.ToString() + " with text :  " + text);
            }
            catch (Exception)
            {

                Reporter.LogFail(" Failed to insert Text in field : " +by.ToString() + " with text :  " + text);

            }
        }

        /// <summary>
        /// Method to enter Text(text) in a text field (elementName)
        /// </summary>
        public static void SetSecureText(this IWebDriver driver, By by, string elementName, string text)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).SendKeys(text);
                Reporter.LogPass("Inserted Text in field : " +by.ToString() + " with text :  " + text);
            }
            catch (Exception)
            {

                Reporter.LogFail(" Failed to insert Text in field : " +by.ToString() + " with text :  " + text);

            }
        }



        /// <summary>
        /// Read text from an element
        /// </summary>
        public static string GetText(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                return fluentWait.Until(x => x.FindElement(by)).Text;
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Failed to get text" + ex);
                return string.Empty;

            }
        }

        /// <summary>
        ///Comparing text on UI with the expected
        /// </summary>
        public static void VerifyText(this IWebDriver driver, By by, string expectedText)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                string actualText = fluentWait.Until(x => x.FindElement(by)).Text;
                if (actualText == expectedText)
                {
                    Reporter.LogPass("Expected and Actual Text Match : " + expectedText);
                }
                else
                {
                    Reporter.LogFailWithScreenshot("Expected and Actual did not Match <br/> Expected : " + expectedText + "<br/> and Actual Text Match : " + actualText);
                }
            }
            catch (Exception ex)
            {
                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);

            }

        }

        /// <summary>
        ///Comparing text on UI with the expected
        /// </summary>
        public static void VerifyText(this IWebDriver driver, By by, string elementName, string expectedText)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                string actualText = fluentWait.Until(x => x.FindElement(by)).Text;
                if (actualText == expectedText)
                {
                    Reporter.LogPass("For element: " + elementName + " Expected and Actual Text Match : " + expectedText);
                }
                else
                {
                    Reporter.LogFailWithScreenshot("For element: " + elementName + " Expected and Actual did not Match <br/> Expected : " + expectedText + "<br/> and Actual Text Match : " + actualText);
                }
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " + elementName + ex);
            }

        }

        /// <summary>
        /// Perform submit  Operation on an element
        /// </summary>
        public static void SubmitButton(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).Submit();
                Reporter.LogPass("Perform submit  Operation on element : " +by.ToString());
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }
        }


        /// <summary>
        /// Perform submit  Operation on an element
        /// </summary>
        public static void SubmitButton(this IWebDriver driver, By by, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).Submit();
                Reporter.LogPass("Perform submit  Operation on element : " + elementName); ;
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }

        }

        /// <summary>
        /// Perform Click Operation on an element
        /// </summary>
        public static void ClickButton(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).Click();
                Reporter.LogPass("Perform click  Operation on element : " +by.ToString());
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }
        }


        /// <summary>
        /// Perform Click Operation on an element
        /// </summary>
        public static void ClickButton(this IWebDriver driver, By by, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                fluentWait.Until(x => x.FindElement(by)).Click();
                Reporter.LogPass("Perform click  Operation on element : " + elementName); ;
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }
        }


        /// <summary>
        /// Return true if the object is enabled and vice versa
        /// </summary>
        public static bool Enabled(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                return fluentWait.Until(x => x.FindElement(by)).Enabled;
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
                return false;
            }
        }

        /// <summary>
        /// Verify to see if the object is enabled
        /// </summary>
        public static void VerifyEnabled(this IWebDriver driver, By by, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                if (fluentWait.Until(x => x.FindElement(by)).Enabled)
                {
                    Reporter.LogPass("Element : " + elementName + " is Enabled");
                }
                else
                {
                    Reporter.LogFailWithScreenshot("Element : " + elementName + " is NOT Enabled");
                }
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }

        }


        /// <summary>
        /// Verify to see if the object is Disabled
        /// </summary>
        public static void VerifyDisabled(this IWebDriver driver, By by, string elementName)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                if (fluentWait.Until(x => x.FindElement(by)).Enabled)
                {
                    Reporter.LogFailWithScreenshot("Element : " + elementName + " is NOT Enabled");
                }
                else
                {
                    Reporter.LogPass("Element : " + elementName + " is Enabled");
                }
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }

        }

        /// <summary>
        /// Select from a dropdown based on selection value
        /// </summary>
        public static void SelectDDL(this IWebDriver driver, By by, string elementName, string value)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                SelectElement ddl = new SelectElement(element);
                ddl.SelectByText(value);
                Reporter.LogPass("Selected " + value + " from " + elementName + " dropdown");
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }

        }

        /// <summary>
        /// Select from a dropdown based on Index
        /// </summary>
        public static void SelectDDLByValue(this IWebDriver driver, By by, string elementName, int index)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                SelectElement ddl = new SelectElement(element);
                ddl.SelectByIndex(index);
                Reporter.LogPass("Selected " + ddl.SelectedOption.Text + " from " + elementName + " dropdown");
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }

        }

        /// <summary>
        /// Select random value from the dropdown
        /// </summary>
        public static void SelectRandomDDLValue(this IWebDriver driver, By by, string elementName, int minIndex = 0)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                SelectElement ddl = new SelectElement(element);
                int count = ddl.Options.Count - 1;
                Random random = new Random();
                ddl.SelectByIndex(random.Next(minIndex, count));
                Reporter.LogPass("Selected " + ddl.SelectedOption.Text + " from " + elementName + " dropdown");
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }
            
        }
        /// <summary>
        /// Return first selected options from the dropdown as a string
        /// </summary>
        public static string GetSelectedDropDown(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                SelectElement ddl = new SelectElement(element);
                return ddl.AllSelectedOptions.First().ToString();
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
                return string.Empty;
            }
            
        }


        /// <summary>
        /// Return all selected options from the dropdown as a list
        /// </summary>
        public static IList<IWebElement> GetSelectedListOptions(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                SelectElement ddl = new SelectElement(element);
                return ddl.AllSelectedOptions;
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
                return null;
            }
            
        }

        /// <summary>
        /// Hover over a field/element
        /// </summary>
        public static void Hover(this IWebDriver driver, By by, string elementName = "")
        {
            try
            {
                Actions action = new Actions(driver);
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                action.MoveToElement(element).Perform();
                Reporter.LogPass("Hover over an element" + elementName);
            }
            catch (Exception ex)
            {
                Reporter.LogFail("Unable to locate the element " +by.ToString() + ex);
            }
            
        }


        /// <summary>
        /// Hover over a field/element and Click
        /// </summary>
        public static void HoverAndClick(this IWebDriver driver, By byToHover, string elementName, By byToclick)
        {
            try
            {
                Actions action = new Actions(driver);
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement elementToHover = fluentWait.Until(x => x.FindElement(byToHover));
                IWebElement elementToClick = fluentWait.Until(x => x.FindElement(byToHover));
                action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
                Reporter.LogPass("Hover over and click element" + elementName);
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " + elementName + ex);
            }
            
        }


        /// <summary>
        /// Assert if the element is Present
        /// </summary>
        public static void AssertElementPresent(this IWebDriver driver, By by, string elementName = "")
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                if (IsElementPresent(driver, by)) { Reporter.LogPass("Verified that the element " + elementName + " is present"); }
                else
                    throw new Exception(string.Format("Element Not Present exception"));
            }
            catch (Exception ex)
            {

                Reporter.LogFail("Unable to locate the element " + elementName + ex); 
            }
           
        }

        /// <summary>
        /// Waiting until the Staleness Of Element
        /// </summary>
        public static void WaitForStalenessOfElement(this IWebDriver driver, By by, int maxTimeOutSec = 10)
        {
            DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
            IWebElement element = fluentWait.Until(x => x.FindElement(by));
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(maxTimeOutSec));
            wait.Until(ExpectedConditions.StalenessOf(element));
        }


        /// <summary>
        /// Waiting for the element to be present
        /// </summary>
        public static void WaitForElementPresent(this IWebDriver driver, By by, string elementName = "", int maxTimeOutSec = 10)
        {
            bool found = false;
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < maxTimeOutSec)
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                if (element.Displayed)
                {
                    found = true;
                    break;
                }
            }


            if (found == false) { Reporter.LogFailWithScreenshot("Not able to find element " + elementName); }
        }

        /// Private method to verify if the element is Present
        private static bool IsElementPresent(this IWebDriver driver, By by)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
                IWebElement element = fluentWait.Until(x => x.FindElement(by));
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }


        /// Private method to get the elementName from element property
        private static string ElementName(this IWebDriver driver, By by)
        {
            DefaultWait<IWebDriver> fluentWait = FluentWait(driver);
            IWebElement element = fluentWait.Until(x => x.FindElement(by));
            return element.GetProperty("id") +
                        element.GetProperty("xpath") +
                        element.GetProperty("CssSelector") +
                        element.GetProperty("LinkText") +
                        element.GetProperty("Name");
        }



        ///fluent wait for element
        public static DefaultWait<IWebDriver> FluentWait(this IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;

        }
    }
}
