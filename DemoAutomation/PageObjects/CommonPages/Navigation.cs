using CynkyWrapper;
using CynkyWrapper.Configuration;
using OpenQA.Selenium;
using System;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class Navigation
    {
        IWebDriver _Driver;

        public Navigation(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement MenuOption_link(string option) => new PageElement(_Driver, By.XPath($"//a[contains(.,'{option}')]"));
        PageElement SystemMessages_label => new PageElement(_Driver, By.XPath("(//div[contains(@class, 'module-SystemMessages')])[2]"));
        PageElement CloseMessageDialog_button => new PageElement(_Driver, By.XPath("(//div[contains(@class, 'dialog-close')])[2]"));
        PageElement CompanyLogo_image => new PageElement(_Driver, By.XPath("//div[@class='company-branding']"));

        #endregion

        #region Actions

        public void NavigateToHomePage()
        {
            _Driver.Navigate().GoToUrl(CynkyConfigManager.SiteUrl);
        }

        public void ClickAlert()
        {
            _Driver.SwitchTo().Alert().Accept();
        }

        public void NavigateToMenuOption(string option)
        {
            if (CompanyLogo_image.IsDisplayed() && SystemMessages_label.ElementExists())
                CloseMessageDialog_button.Click();

            switch (option.ToLower())
            {
                case "contacts":
                    MenuOption_link("Sales & Marketing").Click();
                    break;
                case "reports":
                case "activity log":
                    MenuOption_link("Reports & Settings").Click();
                    break;
                default:
                    throw new Exception("Unknown Menu Option!");
            }
            MenuOption_link(option).Click();
        }

        #endregion
    }
}