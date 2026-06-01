using OpenQA.Selenium;
using SeleniumAutomation.Config;

namespace SeleniumAutomation.Pages
{
    /// <summary>
    /// Home page of the-internet application
    /// </summary>
    public class HomePage : BasePage
    {
        // Locators
        private By _headingLocator = By.XPath("//h1[contains(text(), 'Welcome')]");
        private By _availableExamplesLocator = By.XPath("//h2[contains(text(), 'Available Examples')]");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToHomePage()
        {
            NavigateTo(AppConfig.BaseUrl);
        }

        public bool IsHomePageDisplayed()
        {
            return ElementHelper.IsElementDisplayed(WaitHelper.WaitForElementToBeVisible(_headingLocator));
        }

        public bool IsAvailableExamplesDisplayed()
        {
            return ElementHelper.IsElementDisplayed(WaitHelper.WaitForElementToBeVisible(_availableExamplesLocator));
        }

        public void ClickLink(string linkText)
        {
            By linkLocator = By.LinkText(linkText);
            var element = WaitHelper.WaitForElementToBeClickable(linkLocator);
            ElementHelper.Click(element);
        }

        public string GetHeadingText()
        {
            var element = WaitHelper.WaitForElementToBeVisible(_headingLocator);
            return ElementHelper.GetText(element);
        }
    }
}