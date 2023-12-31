﻿using CynkyDriver;
using DemoAutomation.Models.UI;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class LoginPage
    {
        IWebDriver _Driver;

        public LoginPage(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Username_textbox => new PageElement(_Driver, By.Id("login_user"));
        PageElement Password_textbox => new PageElement(_Driver, By.Id("login_pass"));
        PageElement Login_button => new PageElement(_Driver, By.Id("login_button"));

        #endregion

        #region Actions

        public void Login(LoginUser loginUser)
        {
            Username_textbox.SendKeys(loginUser.Username);
            Password_textbox.SendKeys(loginUser.Password);
            Login_button.Click();
        }

        #endregion
    }
}