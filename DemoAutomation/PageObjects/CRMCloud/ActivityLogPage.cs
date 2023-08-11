using CynkyWrapper;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;

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
        PageElement ActivityItems_label => new PageElement(_Driver, By.XPath("//span[@class='detailLink']/a"));
        PageElement ActivityItem_label(int index = 1) => new PageElement(_Driver, By.XPath($"((//tr[contains(@class,'listViewRow')])[{index}]//span[@class='detailLink']//a)[1]"));
        PageElement Actions_button(int index = 1) => new PageElement(_Driver, By.XPath($"(//span[normalize-space(text()) = 'Actions'])[{index}]"));
        PageElement ActionsOption_dropdown(string option) => new PageElement(_Driver, By.XPath($"//div[text()='{option}']"));

        #endregion

        #region Actions

        public void DeleteActivityItems(int numberOfItems)
        {
            ActivityItems_checkbox.IsDisplayed();
            var activityItems = ActivityItems_checkbox.GetAllElements();
            int counter = 0;
            do
            {
                activityItems[counter].Click();
                counter++;
            } while (counter < numberOfItems);

            Actions_button(2).Click();
            ActionsOption_dropdown("Delete").Click();
            ClickAlert();
        }

        public List<string> GetAllActivityItems()
        {
            int count = ActivityItems_label.GetAllElements().Count;
            List<string> listOfItems = new List<string>();
            int counter = 1;
            var stopwatch = Stopwatch.StartNew();
            do
            {
                if (ActivityItem_label().IsDisplayed())
                {
                    listOfItems.Add(ActivityItem_label(counter).GetText());
                    counter++;
                }
            } while (counter < count && stopwatch.ElapsedMilliseconds < 10000);

            return listOfItems;
        }

        public List<string> GetActivityItems(int numberOfItems)
        {
            List<string> listOfItems = new List<string>();
            int counter = 1;
            var stopwatch = Stopwatch.StartNew();
            while (counter <= numberOfItems && stopwatch.ElapsedMilliseconds < 10000)
            {
                if (ActivityItem_label().IsDisplayed())
                {
                    listOfItems.Add(ActivityItem_label(counter).GetText());
                    counter++;
                }
            }
            return listOfItems;
        }

        #endregion
    }
}