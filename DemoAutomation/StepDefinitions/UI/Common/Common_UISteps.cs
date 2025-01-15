using DemoAutomation.PageObjects.CommonPages;
using Reqnroll;

namespace DemoAutomation.StepDefinitions.UI.Common
{
    [Binding]
    public class Common_UISteps
    {
        Navigation _Navigation;

        public Common_UISteps(ScenarioContext scenarioContext)
        {
            _Navigation = scenarioContext.ScenarioContainer.Resolve<Navigation>();
        }

        [StepDefinition(@"user is on the homepage")]
        public void GivenUserNavigatesToTheHomePage()
        {
            _Navigation.NavigateToHomePage();
        }


    }
}
