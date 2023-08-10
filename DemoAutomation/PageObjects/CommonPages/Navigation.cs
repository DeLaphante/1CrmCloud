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

        #endregion

        #region Actions

        public void NavigateToLandingPage()
        {
            _Driver.Navigate().GoToUrl(CynkyConfigManager.SiteUrl);
        }

        public void ClickAlert()
        {
            _Driver.SwitchTo().Alert().Accept();
        }


        public void NavigateToMenuOption(string option)
        {
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