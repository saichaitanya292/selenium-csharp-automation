using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumAutomation.Config;

namespace SeleniumAutomation.Pages
{
    /// <summary>
    /// Checkboxes page of the-internet application
    /// </summary>
    public class CheckboxesPage : BasePage
    {
        // Locators
        private By _checkboxesLocator = By.CssSelector("input[type='checkbox']");

        public CheckboxesPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToCheckboxesPage()
        {
            NavigateTo($"{AppConfig.BaseUrl}checkboxes");
        }

        public List<IWebElement> GetAllCheckboxes()
        {
            return Driver.FindElements(_checkboxesLocator).ToList();
        }

        public void CheckCheckbox(int index)
        {
            var checkboxes = GetAllCheckboxes();
            if (index < checkboxes.Count && !checkboxes[index].Selected)
            {
                ElementHelper.Click(checkboxes[index]);
            }
        }

        public void UncheckCheckbox(int index)
        {
            var checkboxes = GetAllCheckboxes();
            if (index < checkboxes.Count && checkboxes[index].Selected)
            {
                ElementHelper.Click(checkboxes[index]);
            }
        }

        public bool IsCheckboxChecked(int index)
        {
            var checkboxes = GetAllCheckboxes();
            return checkboxes[index].Selected;
        }

        public int GetCheckboxCount()
        {
            return GetAllCheckboxes().Count;
        }

        public void CheckAllCheckboxes()
        {
            var checkboxes = GetAllCheckboxes();
            foreach (var checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    ElementHelper.Click(checkbox);
                }
            }
        }

        public void UncheckAllCheckboxes()
        {
            var checkboxes = GetAllCheckboxes();
            foreach (var checkbox in checkboxes)
            {
                if (checkbox.Selected)
                {
                    ElementHelper.Click(checkbox);
                }
            }
        }
    }
}
