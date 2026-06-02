Feature: Add/Remove Elements Functionality
  As a user of the-internet application
  I want to add and remove elements dynamically
  So that I can test dynamic element management

  Background:
    Given I navigate to the Add/Remove Elements page

  Scenario: Verify page loads successfully
    Then the Add Element button should be visible
    And there should be no delete buttons initially

  Scenario: Add a single element
    When I click the Add Element button
    Then there should be 1 delete button displayed

  Scenario: Add multiple elements
    When I add 5 elements
    Then there should be 5 delete buttons displayed

  Scenario: Delete a single element
    Given I have added 3 elements
    When I click the first delete button
    Then there should be 2 delete buttons displayed

  Scenario: Delete the last element
    Given I have added 3 elements
    When I click the last delete button
    Then there should be 2 delete buttons displayed

  Scenario: Delete all elements
    Given I have added 5 elements
    When I delete all elements
    Then there should be no delete buttons displayed

  Scenario: Add button remains functional after adding elements
    Given I have added 3 elements
    When I click the Add Element button
    Then there should be 4 delete buttons displayed

  Scenario: Delete middle element
    Given I have added 4 elements
    When I click the delete button at index 1
    Then there should be 3 delete buttons displayed

  Scenario: Add element after deleting some
    Given I have added 5 elements
    And I delete all elements
    When I click the Add Element button
    Then there should be 1 delete button displayed

  Scenario: Verify delete button text
    Given I have added 2 elements
    Then all delete buttons should contain text "Delete"

  Scenario: Sequential add and delete operations
    Given I have added 3 elements
    When I click the first delete button
    And I add 2 more elements
    And I click the last delete button
    And I delete all remaining elements
    Then there should be no delete buttons displayed

  Scenario Outline: Add and verify multiple elements
    When I add <count> elements
    Then there should be <count> delete buttons displayed

    Examples:
      | count |
      | 1     |
      | 2     |
      | 3     |
      | 5     |
      | 10    |

  Scenario: Verify delete button visibility
    Given I have added 2 elements
    Then the delete button at index 0 should be visible
    And the delete button at index 1 should be visible
    And the delete button at index 2 should not be visible

  Scenario: Alternating add and delete operations
    When I click the Add Element button
    Then there should be 1 delete button displayed
    When I click the Add Element button
    Then there should be 2 delete buttons displayed
    When I click the first delete button
    Then there should be 1 delete button displayed
    When I click the Add Element button
    Then there should be 2 delete buttons displayed
    When I click the first delete button
    And I click the first delete button
    Then there should be no delete buttons displayed

  Scenario: Stress test with many elements
    When I add 20 elements
    Then there should be 20 delete buttons displayed
    When I delete all elements
    Then there should be no delete buttons displayed

  Scenario: Delete every other element
    Given I have added 6 elements
    When I delete every other element
    Then there should be 3 delete buttons displayed

  Scenario: Verify element addition persistence
    Given I have added 3 elements
    When I add 2 more elements
    Then there should be 5 delete buttons displayed

  Scenario: Delete all then add new elements
    Given I have added 4 elements
    When I delete all elements
    Then there should be no delete buttons displayed
    When I add 3 elements
    Then there should be 3 delete buttons displayed
