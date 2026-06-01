using OpenQA.Selenium;
using SeleniumAutomation.Config;

namespace SeleniumAutomation.Pages
{
    /// <summary>
    /// Checkboxes page of the-internet application
    /// </summary>
    public class CheckboxesPage : BasePage
    {
        // Locators
        private readonly By _checkboxesLocator = By.CssSelector("input[type='checkbox']");

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
            var checkbox = GetCheckboxAt(index);
            if (!checkbox.Selected)
            {
                ElementHelper.Click(checkbox);
            }
        }

        public void UncheckCheckbox(int index)
        {
            var checkbox = GetCheckboxAt(index);
            if (checkbox.Selected)
            {
                ElementHelper.Click(checkbox);
            }
        }

        public bool IsCheckboxChecked(int index)
        {
            return GetCheckboxAt(index).Selected;
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

        private IWebElement GetCheckboxAt(int index)
        {
            var checkboxes = GetAllCheckboxes();
            if (index < 0 || index >= checkboxes.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Checkbox index must be between 0 and {checkboxes.Count - 1}.");
            }

            return checkboxes[index];
        }
    }
}
