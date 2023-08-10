using BoDi;
using DemoAutomation.Models.UI;
using DemoAutomation.PageObjects.CommonPages;
using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        public CRMCloud_UISteps(IObjectContainer objectContainer)
        {
            _LoginPage = objectContainer.Resolve<LoginPage>();
            _Navigation = objectContainer.Resolve<Navigation>();
            _ContactsPage = objectContainer.Resolve<ContactsPage>();
            _ReportsPage = objectContainer.Resolve<ReportsPage>();
            _ActivityLogPage = objectContainer.Resolve<ActivityLogPage>();
            _ScenarioContext = objectContainer.Resolve<ScenarioContext>();
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
            _ContactsPage.CreateAContact(createContact);
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
            _ReportsPage.SearchReport(report);
        }

        [StepDefinition(@"some results are returned")]
        public void ThenSomeResultsAreReturned()
        {
            _ReportsPage.GetNumberOfResults().Should().BeGreaterThan(0);
        }

        [StepDefinition(@"user deletes first (.*) items on table")]
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
