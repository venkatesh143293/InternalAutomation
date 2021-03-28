using OpenQA.Selenium;

namespace WF.Test.AutomationFramework.CoreLibraryInterfaces
{
    public interface IBaseUIPage
    {
        IBaseUIPage CurrentPage { get; set; }

        IWebDriver WebDriver { get; set; }
    }
}
