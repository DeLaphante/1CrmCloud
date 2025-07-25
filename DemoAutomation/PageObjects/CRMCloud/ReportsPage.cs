﻿using CynkyDriver;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class ReportsPage
    {
        IWebDriver _Driver;

        public ReportsPage(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement SearchFilter_textbox => new PageElement(_Driver, By.Id("filter_text"));
        PageElement Results_link(string report) => new PageElement(_Driver, By.XPath($"//a[text()='{report}']"));
        PageElement Button_button(string text, int index = 1) => new PageElement(_Driver, By.XPath($"(//*[(self::button or self::a or self::input or @onclick or @role='button')  and (contains(translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'),\"{text.ToLower()}\") or contains(@class,\"{text}\") or contains(@title,\"{text}\") or contains(@value,\"{text}\")) and not(contains(@class,'disable') or @disabled)])[{index}]"));
        PageElement ResultsRows_label => new PageElement(_Driver, By.XPath($"//tbody/tr[contains(@class,'listViewRow')]"));

        #endregion

        #region Actions

        public void RunReport(string report)
        {
            SearchFilter_textbox.Clear();
            SearchFilter_textbox.SendKeysNoValidation(report + Keys.Enter);
            Results_link(report).Click();
            Button_button("Run Report").Click();
        }

        public int GetNumberOfResults()
        {
            return ResultsRows_label.GetAllElements().Count;
        }

        #endregion
    }
}