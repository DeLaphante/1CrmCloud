using BoDi;
using DemoAutomation.PageObjects.CommonPages;
using TechTalk.SpecFlow;

namespace DemoAutomation.StepDefinitions.UI.Common
{
    [Binding]
    public sealed class Common_UISteps
    {
        Navigation _Navigation;

        public Common_UISteps(IObjectContainer objectContainer)
        {
            _Navigation = objectContainer.Resolve<Navigation>();
        }

        [StepDefinition(@"user is on the homepage")]
        public void GivenUserNavigatesToTheHomePage()
        {
            _Navigation.NavigateToLandingPage();
        }


    }
}
