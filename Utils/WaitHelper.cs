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
            return _wait.Until(driver => driver.FindElement(locator));
        }

        public bool WaitForElementToDisappear(By locator)
        {
            return _wait.Until(driver =>
            {
                try
                {
                    return driver.FindElements(locator).All(element => !element.Displayed);
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        public void WaitForTextToBePresentInElement(IWebElement element, string text)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
    }
}