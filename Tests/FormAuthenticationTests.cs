using NUnit.Framework;
using SeleniumAutomation.Pages;

namespace SeleniumAutomation.Tests
{
    [TestFixture]
    public class FormAuthenticationTests : BaseTest
    {
        private FormAuthenticationPage _formAuthPage;

        [SetUp]
        public void PageSetup()
        {
            _formAuthPage = new FormAuthenticationPage(Driver);
            _formAuthPage.NavigateToFormAuthenticationPage();
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            // Arrange
            string username = "tomsmith";
            string password = "SuperSecretPassword!";

            // Act
            _formAuthPage.Login(username, password);

            // Assert
            Assert.IsTrue(_formAuthPage.IsLogoutButtonDisplayed(), "Logout button should be displayed after successful login");
            Assert.That(_formAuthPage.GetCurrentUrl(), Does.Contain("secure"), "URL should contain 'secure'");
        }

        [Test]
        public void TestLoginWithInvalidCredentials()
        {
            // Arrange
            string username = "invalid";
            string password = "invalid";

            // Act
            _formAuthPage.Login(username, password);

            // Assert
            string flashMessage = _formAuthPage.GetFlashMessage();
            Assert.That(flashMessage, Does.Contain("Invalid credentials"), "Error message should display for invalid credentials");
        }

        [Test]
        public void TestLoginWithEmptyUsername()
        {
            // Arrange
            string username = "";
            string password = "password";

            // Act
            _formAuthPage.Login(username, password);

            // Assert
            string flashMessage = _formAuthPage.GetFlashMessage();
            Assert.That(flashMessage, Does.Contain("Invalid credentials"), "Error message should display for empty username");
        }

        [Test]
        public void TestLogout()
        {
            // Arrange
            _formAuthPage.Login("tomsmith", "SuperSecretPassword!");
            Assert.IsTrue(_formAuthPage.IsLogoutButtonDisplayed(), "Logout button should be displayed");

            // Act
            _formAuthPage.ClickLogout();

            // Assert
            Assert.That(_formAuthPage.GetCurrentUrl(), Does.Contain("login"), "Should redirect to login page after logout");
        }
    }
}