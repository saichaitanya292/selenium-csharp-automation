using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using SeleniumAutomation.Config;
using SeleniumAutomation.Pages;
using SeleniumAutomation.Utils;

namespace SeleniumAutomation.StepDefinitions
{
    [Binding]
    public class ExampleSteps
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [Given("the browser is ready")]
        public void GivenTheBrowserIsReady()
        {
            _driver = DriverFactory.CreateDriver(AppConfig.BrowserName);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfig.ImplicitWaitSeconds);
            _driver.Manage().Window.Maximize();
            _homePage = new HomePage(_driver);
        }

        [When("I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            EnsureHomePageIsInitialized();
            _homePage.NavigateToHomePage();
        }

        [Then("the home page should display available examples")]
        public void ThenTheHomePageShouldDisplayAvailableExamples()
        {
            EnsureHomePageIsInitialized();

            Assert.Multiple(() =>
            {
                Assert.That(_homePage.IsHomePageDisplayed(), Is.True, "The Internet home page heading should be visible.");
                Assert.That(_homePage.IsAvailableExamplesDisplayed(), Is.True, "The available examples heading should be visible.");
                Assert.That(_homePage.GetHeadingText(), Does.Contain("Welcome to the-internet"));
            });
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }

        private void EnsureHomePageIsInitialized()
        {
            if (_homePage == null)
            {
                throw new InvalidOperationException("The browser setup step must run before interacting with the home page.");
            }
        }
    }
}
