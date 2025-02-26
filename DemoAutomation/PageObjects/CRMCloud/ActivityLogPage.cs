using CynkyDriver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class ActivityLogPage : Navigation
    {
        public ActivityLogPage(IWebDriver driver) : base(driver) { }

        #region Locators

        PageElement ActivityItems_checkbox => new PageElement(_Driver, By.XPath("//tbody/tr[contains(@class,'listViewRow')]//input"));
        PageElement ActivityItems_label => new PageElement(_Driver, By.XPath("(//tr[contains(@class,'listViewRow')])//span[@class='detailLink']//a"));
        PageElement ActivityItem_label(int index = 1) => new PageElement(_Driver, By.XPath($"(((//tr[contains(@class,'listViewRow')])//span[@class='detailLink']//a)[{index}])[1]"));
        PageElement Actions_buttons => new PageElement(_Driver, By.XPath($"//span[normalize-space(text()) = 'Actions']"));
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
            foreach (var item in Actions_buttons.GetAllElements())
            {
                if (item.IsDisplayed())
                {
                    item.Click();
                    break;
                }
            }
            ActionsOption_dropdown("Delete").Click();
            ClickAlert();
        }

        public List<string> GetAllActivityItems()
        {
            List<string> listOfItems = new List<string>();
            foreach (var item in ActivityItems_label.GetAllElements())
            {
                listOfItems.Add(item.GetText());
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