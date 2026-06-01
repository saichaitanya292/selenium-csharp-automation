using OpenQA.Selenium;

namespace SeleniumAutomation.Utils
{
    /// <summary>
    /// Helper class for common element interactions
    /// </summary>
    public class ElementHelper
    {
        private readonly IWebDriver _driver;

        public ElementHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public string GetAttribute(IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public void SelectDropdownByValue(IWebElement element, string value)
        {
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public void SelectDropdownByText(IWebElement element, string text)
        {
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
            selectElement.SelectByText(text);
        }

        public void ScrollToElement(IWebElement element)
        {
            var executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public object ExecuteJavaScript(string script, params object[] args)
        {
            var executor = (IJavaScriptExecutor)_driver;
            return executor.ExecuteScript(script, args);
        }
    }
}