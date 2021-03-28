using WF.Test.AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WF.Test.AutomationFramework.CoreLibrary.UI.Extensions
{
    public static class MultiObjectWebElementExtension
    {
        /// <summary>
        /// Method to enter Text(text) in a text field (elementName) for element type as multi object
        /// </summary>
        public static void SetText(this IList<IWebElement> elements, string fieldName, int objNumber, string text)
        {
            elements[objNumber + 1].SendKeys(text);
            Reporter.LogPass("Inserted Text in field : " + fieldName + " with text :  " + text);

        }


        /// <summary>
        /// Read text from an element of element type as multi object
        /// </summary>
        public static string GetText(this IWebDriver driver, By by, int objNumber)
        {
            DefaultWait<IWebDriver> fluentWait = WebElementExtension.FluentWait(driver);
            IList<IWebElement> elements = fluentWait.Until(x => x.FindElements(by));            
            return elements[objNumber + 1].Text;
        }

        /// <summary>
        /// Method to get the row number where the text is present for an multi object element or table
        /// </summary>
        public static int GetRowNumberForText(this IWebDriver driver, By by, string text)
        {
            DefaultWait<IWebDriver> fluentWait = WebElementExtension.FluentWait(driver);
            IList<IWebElement> elements = fluentWait.Until(x => x.FindElements(by));
            int counter = 1;
            foreach (IWebElement ele in elements)
            {
                if (ele.Text == text)
                {
                    return counter;
                }
                counter = counter + 1;

            }
            return -1;
        }


        /// <summary>
        ///Comparing text on UI with the expected on a multi object element type
        /// </summary>
        public static void VerifyText(this IWebDriver driver, By by, string fieldName, int objNumber, string expectedText)
        {
            DefaultWait<IWebDriver> fluentWait = WebElementExtension.FluentWait(driver);
            IList<IWebElement> elements = fluentWait.Until(x => x.FindElements(by));
            string actualText = elements[objNumber + 1].Text;
            if (actualText == expectedText)
            {
                Reporter.LogPass("For element: " + fieldName + " Expected and Actual Text Match : " + expectedText);
            }
            else
            {
                Reporter.LogFailWithScreenshot("For element: " + fieldName + " Expected and Actual did not Match <br/> Expected : " + expectedText + "<br/> and Actual Text Match : " + actualText);
            }
        }

        /// <summary>
        /// Getting Row Count or count of objects
        /// </summary>
        public static int GetRowCount(this IWebDriver driver, By by)
        {
            DefaultWait<IWebDriver> fluentWait = WebElementExtension.FluentWait(driver);
            return fluentWait.Until(x => x.FindElements(by)).Count;
        }


        /// <summary>
        /// Perform submit  Operation on an element for element type as multi object
        /// </summary>
        public static void Submit(this IWebDriver driver, By by, string elementName, int objNumber)
        {
            DefaultWait<IWebDriver> fluentWait = WebElementExtension.FluentWait(driver);
            IList<IWebElement> elements = fluentWait.Until(x => x.FindElements(by));
            elements[objNumber].Submit();
            Reporter.LogPass("Perform submit Operation on element : " + elementName);
        }

        /// <summary>
        /// Click on an element for element type as multi object
        /// </summary>
        public static void Click(this IWebDriver driver, By by, string elementName, int objNumber)
        {
            DefaultWait<IWebDriver> fluentWait = WebElementExtension.FluentWait(driver);
            IList<IWebElement> elements = fluentWait.Until(x => x.FindElements(by));
            elements[objNumber].Click();
            Reporter.LogPass("Click element : " + elementName);
        }

    }
}
