using NUnit.Framework;
using SeleniumAutomation.Pages;

namespace SeleniumAutomation.Tests
{
    [TestFixture]
    public class DropdownTests : BaseTest
    {
        private DropdownPage _dropdownPage;

        [SetUp]
        public void PageSetup()
        {
            _dropdownPage = new DropdownPage(Driver);
            _dropdownPage.NavigateToDropdownPage();
        }

        [Test]
        public void TestDropdownOptionCount()
        {
            // Act
            int count = _dropdownPage.GetOptionCount();

            // Assert
            Assert.That(count, Is.GreaterThan(0), "Dropdown should have options");
        }

        [Test]
        public void TestSelectOptionByValue()
        {
            // Act
            _dropdownPage.SelectOptionByValue("1");

            // Assert
            string selectedOption = _dropdownPage.GetSelectedOption();
            Assert.That(selectedOption, Does.Contain("Option 1"), "Option 1 should be selected");
        }

        [Test]
        public void TestSelectOptionByText()
        {
            // Act
            _dropdownPage.SelectOptionByText("Option 2");

            // Assert
            string selectedOption = _dropdownPage.GetSelectedOption();
            Assert.That(selectedOption, Does.Contain("Option 2"), "Option 2 should be selected");
        }

        [Test]
        public void TestGetAllOptions()
        {
            // Act
            var options = _dropdownPage.GetAllOptions();

            // Assert
            Assert.That(options.Count, Is.GreaterThan(0), "Should have options");
            Assert.That(options, Does.Contain("Option 1"), "Should contain Option 1");
            Assert.That(options, Does.Contain("Option 2"), "Should contain Option 2");
        }

        [Test]
        public void TestSelectMultipleOptions()
        {
            // Act & Assert
            _dropdownPage.SelectOptionByValue("1");
            Assert.That(_dropdownPage.GetSelectedOption(), Does.Contain("Option 1"));

            _dropdownPage.SelectOptionByValue("2");
            Assert.That(_dropdownPage.GetSelectedOption(), Does.Contain("Option 2"));
        }
    }
}