using NUnit.Framework;
using SeleniumAutomation.Pages;

namespace SeleniumAutomation.Tests
{
    [TestFixture]
    public class CheckboxesTests : BaseTest
    {
        private CheckboxesPage _checkboxesPage;

        [SetUp]
        public void PageSetup()
        {
            _checkboxesPage = new CheckboxesPage(Driver);
            _checkboxesPage.NavigateToCheckboxesPage();
        }

        [Test]
        public void TestCheckboxCount()
        {
            // Act
            int count = _checkboxesPage.GetCheckboxCount();

            // Assert
            Assert.That(count, Is.GreaterThan(0), "Should have at least one checkbox");
        }

        [Test]
        public void TestCheckCheckbox()
        {
            // Arrange
            int checkboxIndex = 0;

            // Act
            _checkboxesPage.CheckCheckbox(checkboxIndex);

            // Assert
            Assert.IsTrue(_checkboxesPage.IsCheckboxChecked(checkboxIndex), "Checkbox should be checked");
        }

        [Test]
        public void TestUncheckCheckbox()
        {
            // Arrange
            int checkboxIndex = 0;
            _checkboxesPage.CheckCheckbox(checkboxIndex);

            // Act
            _checkboxesPage.UncheckCheckbox(checkboxIndex);

            // Assert
            Assert.IsFalse(_checkboxesPage.IsCheckboxChecked(checkboxIndex), "Checkbox should be unchecked");
        }

        [Test]
        public void TestCheckAllCheckboxes()
        {
            // Act
            _checkboxesPage.CheckAllCheckboxes();

            // Assert
            int count = _checkboxesPage.GetCheckboxCount();
            for (int i = 0; i < count; i++)
            {
                Assert.IsTrue(_checkboxesPage.IsCheckboxChecked(i), $"Checkbox at index {i} should be checked");
            }
        }

        [Test]
        public void TestUncheckAllCheckboxes()
        {
            // Arrange
            _checkboxesPage.CheckAllCheckboxes();

            // Act
            _checkboxesPage.UncheckAllCheckboxes();

            // Assert
            int count = _checkboxesPage.GetCheckboxCount();
            for (int i = 0; i < count; i++)
            {
                Assert.IsFalse(_checkboxesPage.IsCheckboxChecked(i), $"Checkbox at index {i} should be unchecked");
            }
        }
    }
}