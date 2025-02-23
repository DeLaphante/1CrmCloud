using CynkyDriver;
using DemoAutomation.Models.UI;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class ContactsPage
    {
        IWebDriver _Driver;

        public ContactsPage(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement MenuOption_link(string option) => new PageElement(_Driver, By.XPath($"//a[contains(.,'{option}')]"));
        PageElement Contact_textbox(string fieldName) => new PageElement(_Driver, By.XPath($"//input[@name='{fieldName}']"));
        PageElement Title_dropdown => new PageElement(_Driver, By.XPath("(//div[contains(@id,'DetailFormsalutation-input')])[2]"));
        PageElement Category_dropdown => new PageElement(_Driver, By.Id("DetailFormcategories-input"));
        PageElement Role_dropdown => new PageElement(_Driver, By.Id("DetailFormbusiness_role-input-label"));
        PageElement Option_dropdown(string option) => new PageElement(_Driver, By.XPath($"//div[text()='{option}']"));
        PageElement Button_button(string option, int index = 1) => new PageElement(_Driver, By.XPath($"(//*[translate(normalize-space(.),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz')= \"{option.ToLower()}\"]//ancestor::*[(self::button or self::a or @onclick or @role='button') and not(contains(@class,'banner') or contains(@class,'disable') or @disabled)])[{index}]"));
        PageElement Header_label(int index = 1) => new PageElement(_Driver, By.XPath($"(//h3)[{index}]"));
        PageElement Category_label => new PageElement(_Driver, By.XPath($"//li[contains(.,'Category')]"));
        PageElement BusinessRole_label => new PageElement(_Driver, By.XPath($"//p[text()='Business Role']//following-sibling::div"));

        #endregion

        #region Actions

        public void CreateContact(CreateContact createContact)
        {
            MenuOption_link("Create Contact").Click();
            Title_dropdown.Click();
            Option_dropdown(createContact.Title).Click();
            Contact_textbox("first_name").SendKeys(createContact.FirstName);
            Contact_textbox("last_name").SendKeys(createContact.LastName);
            foreach (var category in createContact.Category)
            {
                Category_dropdown.Click();
                Option_dropdown(category).Click();
            }
            Role_dropdown.Click();
            Option_dropdown(createContact.Role).Click();
            Button_button("Save", 3).Click();
        }

        public string GetContactHeaderText()
        {
            return Header_label(2).GetText();
        }

        public string GetCategoryText()
        {
            return Category_label.GetText();
        }

        public string GetBusinessRoleText()
        {
            return BusinessRole_label.GetText();
        }

        #endregion
    }
}