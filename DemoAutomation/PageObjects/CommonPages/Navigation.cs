﻿using CynkyDriver;
using CynkyDriver.Configuration;
using OpenQA.Selenium;
using System;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class Navigation
    {
        protected IWebDriver _Driver;

        public Navigation(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement MenuOption_link(string option) => new PageElement(_Driver, By.XPath($"//a[contains(.,'{option}')]"));
        PageElement CloseMessageDialog_button => new PageElement(_Driver, By.XPath("//div[contains(@id,'sysmsg')]//div[contains(@class, 'dialog-close')]"));

        #endregion

        #region Actions

        public void NavigateToHomePage()
        {
            _Driver.Navigate().GoToUrl(CynkyConfigManager.BaseSiteUrl);
        }

        public void ClickAlert()
        {
            _Driver.SwitchTo().Alert().Accept();
        }

        public void NavigateToMenuOption(string option)
        {
            if (CloseMessageDialog_button.IsDisplayed())
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