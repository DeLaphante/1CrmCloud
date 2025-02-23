using DemoAutomation.Models.UI;
using DemoAutomation.PageObjects.CommonPages;
using FluentAssertions;
using Reqnroll;
using Reqnroll.Assist;
using System.Collections.Generic;

namespace DemoAutomation.StepDefinitions.UI
{
    [Binding]
    public class CRMCloud_UISteps
    {

        LoginPage _LoginPage;
        Navigation _Navigation;
        ContactsPage _ContactsPage;
        ReportsPage _ReportsPage;
        ActivityLogPage _ActivityLogPage;
        ScenarioContext _ScenarioContext;

        public CRMCloud_UISteps(ScenarioContext scenarioContext)
        {
            _LoginPage = scenarioContext.ScenarioContainer.Resolve<LoginPage>();
            _Navigation = scenarioContext.ScenarioContainer.Resolve<Navigation>();
            _ContactsPage = scenarioContext.ScenarioContainer.Resolve<ContactsPage>();
            _ReportsPage = scenarioContext.ScenarioContainer.Resolve<ReportsPage>();
            _ActivityLogPage = scenarioContext.ScenarioContainer.Resolve<ActivityLogPage>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }

        [StepDefinition(@"user with the following details logs in:")]
        public void WhenUserWithTheFollowingDetailsLogsIn(Table table)
        {
            var loginUser = table.CreateInstance<LoginUser>();
            _ScenarioContext.Set<LoginUser>(loginUser, "loginUser");
            _LoginPage.Login(loginUser);
        }


        [StepDefinition(@"logged in user is on the '([^']*)' page")]
        public void GivenLoggedInUserIsOnThePage(string page)
        {
            _Navigation.NavigateToMenuOption(page);
        }

        [StepDefinition(@"user creates a contact")]
        public void WhenUserCreatesAContact()
        {
            var createContact = new CreateContact();
            _ScenarioContext.Set<CreateContact>(createContact, "contact");
            _ContactsPage.CreateContact(createContact);
        }

        [StepDefinition(@"created contact is successfully added")]
        public void ThenCreatedContactIsSuccessfullyAdded()
        {
            var contact = _ScenarioContext.Get<CreateContact>("contact");
            _ContactsPage.GetBusinessRoleText().Should().Be(contact.Role);
            foreach (var category in contact.Category)
            {
                _ContactsPage.GetCategoryText().Should().Contain(category);
            }
            _ContactsPage.GetContactHeaderText().Should().Contain($"{contact.Title} {contact.FirstName} {contact.LastName}");
        }

        [StepDefinition(@"user runs a '([^']*)' report")]
        public void WhenUserRunsAReport(string report)
        {
            _ReportsPage.RunReport(report);
        }

        [StepDefinition(@"some results are returned")]
        public void ThenSomeResultsAreReturned()
        {
            _ReportsPage.GetNumberOfResults().Should().BeGreaterThan(0);
        }

        [StepDefinition(@"user deletes first '(.*)' items on table")]
        public void WhenUserDeletesFirstItemsOnTable(int items)
        {
            _ScenarioContext.Set<List<string>>(_ActivityLogPage.GetActivityItems(items), "activityLogItems");
            _ActivityLogPage.DeleteActivityItems(items);
        }

        [StepDefinition(@"the items should be removed")]
        public void ThenTheItemsShouldBeRemoved()
        {
            var previousItems = _ScenarioContext.Get<List<string>>("activityLogItems");
            var currentItems = _ActivityLogPage.GetAllActivityItems();

            foreach (var previousItem in previousItems)
            {
                foreach (var currentItem in currentItems)
                {
                    currentItem.Should().NotBe(previousItem);
                }
            }
        }
    }
}
