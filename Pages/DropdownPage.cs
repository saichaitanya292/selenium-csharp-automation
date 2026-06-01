using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Config;

namespace SeleniumAutomation.Pages
{
    /// <summary>
    /// Dropdown page of the-internet application
    /// </summary>
    public class DropdownPage : BasePage
    {
        // Locators
        private By _dropdownLocator = By.Id("dropdown");

        public DropdownPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToDropdownPage()
        {
            NavigateTo($"{AppConfig.BaseUrl}dropdown");
        }

        public void SelectOptionByValue(string value)
        {
            var dropdown = WaitHelper.WaitForElementToBeVisible(_dropdownLocator);
            ElementHelper.SelectDropdownByValue(dropdown, value);
        }

        public void SelectOptionByText(string text)
        {
            var dropdown = WaitHelper.WaitForElementToBeVisible(_dropdownLocator);
            ElementHelper.SelectDropdownByText(dropdown, text);
        }

        public string GetSelectedOption()
        {
            var dropdown = WaitHelper.WaitForElementToBeVisible(_dropdownLocator);
            var selectElement = new SelectElement(dropdown);
            return selectElement.SelectedOption.Text;
        }

        public List<string> GetAllOptions()
        {
            var dropdown = WaitHelper.WaitForElementToBeVisible(_dropdownLocator);
            var selectElement = new SelectElement(dropdown);
            return selectElement.Options.Select(o => o.Text).ToList();
        }

        public int GetOptionCount()
        {
            var dropdown = WaitHelper.WaitForElementToBeVisible(_dropdownLocator);
            var selectElement = new SelectElement(dropdown);
            return selectElement.Options.Count;
        }
    }
}