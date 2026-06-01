using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            var options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-popup-blocking");

            if (IsRunningInCi())
            {
                options.AddArguments("--headless=new");
                options.AddArguments("--no-sandbox");
                options.AddArguments("--disable-dev-shm-usage");
                options.AddArguments("--window-size=1920,1080");
            }

            return new ChromeDriver(options);
        }

        private static bool IsRunningInCi()
        {
            return string.Equals(Environment.GetEnvironmentVariable("CI"), "true", StringComparison.OrdinalIgnoreCase)
                || string.Equals(Environment.GetEnvironmentVariable("GITHUB_ACTIONS"), "true", StringComparison.OrdinalIgnoreCase);
        }
    }
}
