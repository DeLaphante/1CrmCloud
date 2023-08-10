using CynkyWrapper;
using OpenQA.Selenium;
using System.Diagnostics;

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
        PageElement Button_button(string option, int index = 1) => new PageElement(_Driver, By.XPath($"(//button[contains(.,'{option}')])[{index}]"));
        PageElement ResultsRows_label => new PageElement(_Driver, By.XPath($"//tbody/tr[contains(@class,'listViewRow')]"));


        #endregion

        #region Actions

        public void SearchReport(string report)
        {
            while (!Results_link(report).ElementExists())
            {
                SearchFilter_textbox.Clear();
                SearchFilter_textbox.SendKeysNoValidation(report + Keys.Enter);
            }

            Results_link(report).Click();
            do
            {
                Button_button("Run Report").Click();
            } while (!ResultsRows_label.ElementExists());
        }

        public int GetNumberOfResults()
        {
            var stopwatch = Stopwatch.StartNew();
            int count = 0;
            do
            {
                count = ResultsRows_label.GetAllElements().Count;
            } while (count.Equals(0) && stopwatch.ElapsedMilliseconds < 10000);
            return count;
        }

        #endregion
    }
}