using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomation.Utils
{
    /// <summary>
    /// Helper class for explicit waits
    /// </summary>
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver, int timeoutSeconds)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
        }

        public IWebElement WaitForElementToBeVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForElementToBeClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public IWebElement WaitForElementToExist(By locator)
        {
            return _wait.Until(ExpectedConditions.PresenceOfElementLocated(locator));
        }

        public bool WaitForElementToDisappear(By locator)
        {
            return _wait.Until(ExpectedConditions.StalenessOf(_driver.FindElement(locator)));
        }

        public void WaitForTextToBePresentInElement(IWebElement element, string text)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
    }
}