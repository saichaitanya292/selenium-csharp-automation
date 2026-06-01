using OpenQA.Selenium;
using SeleniumAutomation.Config;
using SeleniumAutomation.Utils;

namespace SeleniumAutomation.Pages
{
    /// <summary>
    /// Base page class with common page operations
    /// </summary>
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }
        protected WaitHelper WaitHelper { get; set; }
        protected ElementHelper ElementHelper { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            WaitHelper = new WaitHelper(driver, AppConfig.ExplicitWaitSeconds);
            ElementHelper = new ElementHelper(driver);
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public void WaitForPageLoad()
        {
            WaitHelper.WaitForElementToExist(By.TagName("body"));
        }
    }
}