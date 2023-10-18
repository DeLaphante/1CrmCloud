using CynkyWrapper;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class ActivityLogPage : Navigation
    {
        IWebDriver _Driver;

        public ActivityLogPage(IWebDriver driver) : base(driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement ActivityItems_checkbox => new PageElement(_Driver, By.XPath("//tbody/tr[contains(@class,'listViewRow')]//input"));
        PageElement ActivityItems_label => new PageElement(_Driver, By.XPath("(//tr[contains(@class,'listViewRow')])//span[@class='detailLink']//a"));
        PageElement ActivityItem_label(int index = 1) => new PageElement(_Driver, By.XPath($"(((//tr[contains(@class,'listViewRow')])//span[@class='detailLink']//a)[{index}])[1]"));
        PageElement Actions_button(int index = 1) => new PageElement(_Driver, By.XPath($"(//span[normalize-space(text()) = 'Actions'])[{index}]"));
        PageElement ActionsOption_dropdown(string option) => new PageElement(_Driver, By.XPath($"//div[text()='{option}']"));

        #endregion

        #region Actions

        public void DeleteActivityItems(int numberOfItems)
        {
            var activityItems = ActivityItems_checkbox.GetAllElements();
            for (int counter = 0; counter < numberOfItems; counter++)
            {
                activityItems[counter].Click();
            }
            Actions_button(2).Click();
            ActionsOption_dropdown("Delete").Click();
            ClickAlert();
        }

        public List<string> GetAllActivityItems()
        {
            int count = ActivityItems_label.GetAllElements().Count;
            List<string> listOfItems = new List<string>();
            for (int counter = 1; counter < count; counter++)
            {
                listOfItems.Add(ActivityItem_label(counter).GetText());
            }
            return listOfItems;
        }

        public List<string> GetActivityItems(int numberOfItems)
        {
            List<string> listOfItems = new List<string>();
            for (int counter = 1; counter < numberOfItems; counter++)
            {
                listOfItems.Add(ActivityItem_label(counter).GetText());
            }
            return listOfItems;
        }

        #endregion
    }
}