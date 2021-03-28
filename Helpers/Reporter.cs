using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using WF.Test.AutomationFramework.ConfigParser;
using WF.Test.AutomationFramework.CoreLibrary.UI;


namespace WF.Test.AutomationFramework.Helpers
{
    public class Reporter

    {

        public static AventStack.ExtentReports.ExtentReports Extent;
        public static ExtentTest Test;


        /// <summary>
        /// Initializing and starting the Reporter
        /// </summary>
        public static void StartReport()
        {

            //Append the html report file to current project path
            string projectPath = CommonHelpers.GetPath();
            string reportPath = projectPath + UIConfigSettings.ReportPath;
            if (Extent == null)
            {
                //Extent = new ExtentReports(reportPath, true);
                Extent = new AventStack.ExtentReports.ExtentReports();

                var htmlReporter = new ExtentHtmlReporter(reportPath);
                htmlReporter.Config.Theme = Theme.Standard;
                htmlReporter.LoadConfig(projectPath + "extentConfig.xml");
                // create ExtentReports and attach reporter(s)
                Extent.AttachReporter(htmlReporter);
            }
            else
            {
                var htmlReports = new ExtentHtmlReporter(reportPath);
                Extent.AttachReporter(htmlReports);
            }

        }


        /// <summary>
        /// Start New Test case
        /// </summary>
        public static ExtentTest NewTestCase(string testName, string details)
        {
            Test = Extent.CreateTest(testName, details);
            return Test;
        }


        /// <summary>
        /// Log/Report Information
        /// </summary>
        public static void LogInfo(string details)
        {
            Test.Log(Status.Info, details);
        }


        /// <summary>
        /// Log/Report Pass status
        /// </summary>
        public static void LogPass(string details)
        {
            Test.Pass(details);
            Flush();
        }

        /// <summary>
        /// Log/Report Fail status
        /// </summary>
        public static void LogFail(string details)
        {
            Test.Fail(details);
            Flush();
        }

        /// <summary>
        /// Log/Report Fail status along with Screenshot
        /// </summary>
        public static void LogFailWithScreenshot(string details)
        {
            string SSfile = CaptureAndDisplayScreenShot(Driver.WebDriver, Test);
            Test.Fail(details, MediaEntityBuilder.CreateScreenCaptureFromPath(SSfile).Build());
            // Test with snapshot
            Test.AddScreenCaptureFromPath(SSfile);
            Flush();
        }

        /// <summary>
        /// Commit report so all the reporting events are published
        /// </summary>
        public static void Flush()
        {
            Extent.Flush();
        }

        /// <summary>
        ///Commit report so all the reporting events are published
        /// </summary>
        public static void EndReport()
        {
            Extent.Flush();
        }

        //Method that captures screenshot 
        private static string CaptureAndDisplayScreenShot(IWebDriver driver, ExtentTest test)
        {
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string reportPath = CommonHelpers.GetPath() + UIConfigSettings.ReportPath + "\\Screenshots\\";
            //To save screenshot
            CommonHelpers.CreateFolderIfMissing(reportPath);
            string SSfile = reportPath + string.Format("{0:yyyymmddhhmmss}", DateTime.Now) + ".png";
            file.SaveAsFile(SSfile, ScreenshotImageFormat.Png);
            return SSfile;

        }

    }
}

