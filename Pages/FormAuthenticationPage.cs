using OpenQA.Selenium;
using SeleniumAutomation.Config;

namespace SeleniumAutomation.Pages
{
    /// <summary>
    /// Form Authentication page of the-internet application
    /// </summary>
    public class FormAuthenticationPage : BasePage
    {
        // Locators
        private readonly By _usernameInputLocator = By.Id("username");
        private readonly By _passwordInputLocator = By.Id("password");
        private readonly By _loginButtonLocator = By.XPath("//button[@type='submit']");
        private readonly By _flashMessageLocator = By.Id("flash");
        private readonly By _logoutButtonLocator = By.LinkText("Logout");

        public FormAuthenticationPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToFormAuthenticationPage()
        {
            NavigateTo($"{AppConfig.BaseUrl}login");
        }

        public void EnterUsername(string username)
        {
            var usernameField = WaitHelper.WaitForElementToBeVisible(_usernameInputLocator);
            ElementHelper.SendKeys(usernameField, username);
        }

        public void EnterPassword(string password)
        {
            var passwordField = WaitHelper.WaitForElementToBeVisible(_passwordInputLocator);
            ElementHelper.SendKeys(passwordField, password);
        }

        public void ClickLoginButton()
        {
            var loginButton = WaitHelper.WaitForElementToBeClickable(_loginButtonLocator);
            ElementHelper.Click(loginButton);
        }

        public string GetFlashMessage()
        {
            var flashMessage = WaitHelper.WaitForElementToBeVisible(_flashMessageLocator);
            return ElementHelper.GetText(flashMessage).Trim();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public bool IsLogoutButtonDisplayed()
        {
            try
            {
                return ElementHelper.IsElementDisplayed(WaitHelper.WaitForElementToBeVisible(_logoutButtonLocator));
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public void ClickLogout()
        {
            var logoutButton = WaitHelper.WaitForElementToBeClickable(_logoutButtonLocator);
            ElementHelper.Click(logoutButton);
        }
    }
}
