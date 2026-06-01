using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomation.Utils
{
    /// <summary>
    /// Factory class for WebDriver initialization
    /// </summary>
    public class DriverFactory
    {
        public static IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                _ => throw new ArgumentException($"Browser {browserName} is not supported")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            
            var options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-popup-blocking");
            
            return new ChromeDriver(options);
        }
    }
}