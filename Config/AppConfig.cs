namespace SeleniumAutomation.Config
{
    /// <summary>
    /// Application configuration class
    /// </summary>
    public class AppConfig
    {
        public static string BaseUrl => "https://the-internet.herokuapp.com/";
        public static int ImplicitWaitSeconds => 10;
        public static int ExplicitWaitSeconds => 15;
        public static string BrowserName => "chrome";
    }
}