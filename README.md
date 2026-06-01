# Selenium C# Automation with Cucumber - The Internet

This project is a Selenium C# automation framework for testing [The Internet](https://the-internet.herokuapp.com/) application using Reqnroll with the Page Object Model (POM) design pattern and BDD (Behavior-Driven Development) approach.

## Prerequisites

- .NET SDK (6.0 or later)
- Visual Studio or Visual Studio Code
- Chrome browser (for ChromeDriver)

## Project Structure

```
selenium-csharp-automation/
├── Features/             # Gherkin feature files (.feature)
├── StepDefinitions/      # Step definition classes for Cucumber scenarios
├── Pages/                # Page Object Model classes
├── Tests/                # Test classes
├── Utils/                # Utility classes
├── Config/               # Configuration files
├── bin/                  # Build output
├── obj/                  # Object files
└── selenium-csharp-automation.csproj
```

## Getting Started

1. Clone the repository
2. Restore NuGet packages: `dotnet restore`
3. Build the project: `dotnet build`
4. Run tests: `dotnet test`

## Technologies Used

- **Selenium WebDriver**: Browser automation
- **Reqnroll**: BDD/Cucumber framework for .NET
- **NUnit**: Testing framework
- **WebDriverManager**: Driver management
- **FluentAssertions**: Assertion library

## Features

- Behavior-Driven Development (BDD) using Gherkin syntax
- Page Object Model (POM) design pattern
- Fluent assertions
- Implicit and explicit waits
- Element interactions (click, type, select, etc.)
- Screenshot capture on test failure
- Reqnroll test runner integration

## Writing Tests with Cucumber/Reqnroll

### Example Feature File

Create `.feature` files in the `Features/` directory:

```gherkin
Feature: Login functionality
  As a user
  I want to log in to the application
  So that I can access my account

  Scenario: Successful login with valid credentials
    Given I navigate to the login page
    When I enter valid credentials
    And I click the login button
    Then I should be redirected to the dashboard
```

### Example Step Definition

Create step definition classes in the `StepDefinitions/` directory:

```csharp
using Reqnroll;
using YourNamespace.Pages;

[Binding]
public class LoginSteps
{
    private IWebDriver _driver;
    private LoginPage _loginPage;

    public LoginSteps(IWebDriver driver)
    {
        _driver = driver;
        _loginPage = new LoginPage(_driver);
    }

    [Given("I navigate to the login page")]
    public void NavigateToLoginPage()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
    }

    [When("I enter valid credentials")]
    public void EnterValidCredentials()
    {
        _loginPage.EnterUsername("tomsmith");
        _loginPage.EnterPassword("SuperSecretPassword!");
    }

    [When("I click the login button")]
    public void ClickLoginButton()
    {
        _loginPage.ClickLoginButton();
    }

    [Then("I should be redirected to the dashboard")]
    public void VerifyDashboard()
    {
        Assert.That(_driver.Url, Does.Contain("/secure"));
    }
}
```

## Running Cucumber Tests

```bash
# Run all tests
dotnet test

# Run specific feature file
dotnet test --filter "Category=LoginTests"
```

## Resources

- [Reqnroll Documentation](https://docs.reqnroll.net/)
- [Gherkin Syntax](https://cucumber.io/docs/gherkin/)
- [Selenium WebDriver C# Documentation](https://www.selenium.dev/documentation/webdriver/)
