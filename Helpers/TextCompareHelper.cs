using System;

namespace WF.Test.AutomationFramework.Helpers
{
    public class TextCompareHelper
    {
        public TextCompareHelper()
        {

        }

        /// <summary>
        /// Verify text and report.
        /// </summary>
        public static void VerifyText(String elementName, String expectedText, String actualText)
        {
            if (expectedText == actualText)
            {
                Reporter.LogPass("Verified Text for " + elementName + " as " + expectedText);

            }
            else
            {
                Reporter.LogFail("Expected and Actual Text for " + elementName + " did not Match  <br> " +
                    "Expected Text : " + expectedText + "<br>" +
                    "Actual Text : " + actualText);
            }
        }
        /// <summary>
        ///Compare Text ignoring the case
        /// </summary>
        public static void VerifyTextIgnoreCase(String elementName, String expectedText, String actualText)
        {
            if (expectedText.ToLower() == actualText.ToLower())
            {
                Reporter.LogPass("Verified Text for " + elementName + " as " + expectedText);

            }
            else
            {
                Reporter.LogFail("Expected and Actual Text for " + elementName + " did not Match  <br> " +
                    "Expected Text : " + expectedText + "<br>" +
                    "Actual Text : " + actualText);
            }
        }

        /// <summary>
        /// Verify if actualTextContainsIn is in expectedText
        /// </summary>

        public static void VerifyTextContains(String elementName, String expectedText, String actualTextContainsIn)
        {
            if (expectedText.Contains(actualTextContainsIn))
            {
                Reporter.LogPass("Verified Text contains for " + elementName + " as " + expectedText);

            }
            else
            {
                Reporter.LogFail("Expected  for " + elementName + " does not contain Actual Text  <br> " +
                    "Expected Text : " + expectedText + "<br>" +
                    "Actual Text : " + actualTextContainsIn);
            }
        }
    }
}
