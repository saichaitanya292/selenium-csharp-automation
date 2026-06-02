using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.Config;
using SeleniumAutomation.Pages;

namespace SeleniumAutomation.StepDefinitions
{
    [Binding]
    public class AddRemoveElementsSteps
    {
        private IWebDriver _driver;
        private AddRemoveElementsPage _page;

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(AppConfig.ImplicitWaitSeconds);
            _page = new AddRemoveElementsPage(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }

        [Given("I navigate to the Add/Remove Elements page")]
        public void NavigateToAddRemoveElementsPage()
        {
            _page.NavigateToAddRemoveElementsPage();
        }

        [Then("the Add Element button should be visible")]
        public void VerifyAddElementButtonIsVisible()
        {
            Assert.IsTrue(_page.IsAddElementButtonVisible(), "Add Element button should be visible");
        }

        [Then("there should be no delete buttons initially")]
        public void VerifyNoDeleteButtonsInitially()
        {
            int count = _page.GetDeleteButtonCount();
            Assert.AreEqual(0, count, "There should be no delete buttons initially");
        }

        [When("I click the Add Element button")]
        public void ClickAddElementButton()
        {
            _page.ClickAddElementButton();
        }

        [Then("there should be (\\d+) delete button(?:s)? displayed")]
        public void VerifyDeleteButtonCount(int expectedCount)
        {
            int actualCount = _page.GetDeleteButtonCount();
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} delete button(s), but found {actualCount}");
        }

        [Given("I have added (\\d+) element(?:s)?")]
        public void AddMultipleElements(int count)
        {
            _page.AddMultipleElements(count);
        }

        [When("I add (\\d+) element(?:s)?")]
        public void WhenAddMultipleElements(int count)
        {
            _page.AddMultipleElements(count);
        }

        [When("I click the first delete button")]
        public void ClickFirstDeleteButton()
        {
            _page.ClickFirstDeleteButton();
        }

        [When("I click the last delete button")]
        public void ClickLastDeleteButton()
        {
            _page.ClickLastDeleteButton();
        }

        [When("I delete all element(?:s)?")]
        public void DeleteAllElements()
        {
            _page.DeleteAllElements();
        }

        [When("I click the delete button at index (\\d+)")]
        public void ClickDeleteButtonAtIndex(int index)
        {
            _page.ClickDeleteButton(index);
        }

        [Then("all delete buttons should contain text \"(.*)\"")]
        public void VerifyDeleteButtonText(string expectedText)
        {
            var texts = _page.GetAllDeleteButtonTexts();
            Assert.IsTrue(texts.Count > 0, "No delete buttons found");
            foreach (var text in texts)
            {
                Assert.That(text, Does.Contain(expectedText), $"Delete button text should contain '{expectedText}'");
            }
        }

        [Then("the delete button at index (\\d+) should be visible")]
        public void VerifyDeleteButtonIsVisible(int index)
        {
            Assert.IsTrue(_page.IsDeleteButtonVisible(index), $"Delete button at index {index} should be visible");
        }

        [Then("the delete button at index (\\d+) should not be visible")]
        public void VerifyDeleteButtonNotVisible(int index)
        {
            Assert.IsFalse(_page.IsDeleteButtonVisible(index), $"Delete button at index {index} should not be visible");
        }

        [When("I delete every other element")]
        public void DeleteEveryOtherElement()
        {
            int count = _page.GetDeleteButtonCount();
            for (int i = 0; i < count / 2; i++)
            {
                _page.ClickFirstDeleteButton();
                if (_page.GetDeleteButtonCount() > 0)
                {
                    _page.ClickFirstDeleteButton();
                }
            }
        }

        [When("I add (\\d+) more element(?:s)?")]
        public void AddMoreElements(int count)
        {
            _page.AddMultipleElements(count);
        }

        [And("I click the first delete button")]
        public void AndClickFirstDeleteButton()
        {
            _page.ClickFirstDeleteButton();
        }

        [And("I add (\\d+) more element(?:s)?")]
        public void AndAddMoreElements(int count)
        {
            _page.AddMultipleElements(count);
        }

        [And("I click the last delete button")]
        public void AndClickLastDeleteButton()
        {
            _page.ClickLastDeleteButton();
        }

        [And("I delete all element(?:s)?")]
        public void AndDeleteAllElements()
        {
            _page.DeleteAllElements();
        }

        [And("I delete all remaining element(?:s)?")]
        public void AndDeleteAllRemainingElements()
        {
            _page.DeleteAllElements();
        }
    }
}
