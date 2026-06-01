# Selenium C# Automation - The Internet

This project is a Selenium C# automation framework for testing [The Internet](https://the-internet.herokuapp.com/) application using the Page Object Model (POM) design pattern.

## Prerequisites

- .NET SDK (6.0 or later)
- Visual Studio or Visual Studio Code
- Chrome browser (for ChromeDriver)

## Project Structure

```
selenium-csharp-automation/
├── Pages/               # Page Object Model classes
├── Tests/               # Test classes
├── Utils/               # Utility classes
├── Config/              # Configuration files
├── bin/                 # Build output
├── obj/                 # Object files
└── selenium-csharp-automation.csproj
```

## Getting Started

1. Clone the repository
2. Restore NuGet packages: `dotnet restore`
3. Build the project: `dotnet build`
4. Run tests: `dotnet test`

## Technologies Used

- **Selenium WebDriver**: Browser automation
- **NUnit**: Testing framework
- **WebDriverManager**: Driver management

## Features

- Page Object Model (POM) design pattern
- Fluent assertions
- Implicit and explicit waits
- Element interactions (click, type, select, etc.)
- Screenshot capture on test failure
