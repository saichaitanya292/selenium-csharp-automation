using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            try
            {
                CaptureScreenshotOnFailure();
            }
            finally
            {
                Driver?.Quit();
            }
        }

        private void CaptureScreenshotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed || Driver is not ITakesScreenshot screenshotDriver)
            {
                return;
            }

            string screenshotsDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotsDirectory);

            string testName = SanitizeFileName(TestContext.CurrentContext.Test.Name);
            string screenshotPath = Path.Combine(screenshotsDirectory, $"{testName}.png");

            try
            {
                screenshotDriver.GetScreenshot().SaveAsFile(screenshotPath);
                TestContext.AddTestAttachment(screenshotPath, "Failure screenshot");
            }
            catch (WebDriverException ex)
            {
                TestContext.Error.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }

        private static string SanitizeFileName(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            return string.Concat(fileName.Select(character => invalidChars.Contains(character) ? '_' : character));
        }
    }
}
