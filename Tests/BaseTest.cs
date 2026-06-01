using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Config;
using SeleniumAutomation.Utils;

namespace SeleniumAutomation.Tests
{
    /// <summary>
    /// Base test class with setup and teardown
    /// </summary>
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.CreateDriver(AppConfig.BrowserName);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfig.ImplicitWaitSeconds);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}