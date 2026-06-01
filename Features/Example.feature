Feature: Home page
  Verify that The Internet home page is available and lists examples.

  Scenario: Home page displays available examples
    Given the browser is ready
    When I navigate to the home page
    Then the home page should display available examples
