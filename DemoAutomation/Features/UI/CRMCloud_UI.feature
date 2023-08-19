@CRMCloud
Feature: CRMCloud_UI

Background: Navigate to homepage
	Given user is on the homepage
	When user with the following details logs in:
		| Property | Value |
		| Username | admin |
		| Password | admin |


Scenario: Create contact
	Given logged in user is on the 'Contacts' page
	When user creates a contact
	Then created contact is successfully added


Scenario: Run report
	Given logged in user is on the 'Reports' page
	When user runs a 'Project Profitability' report
	Then some results are returned


Scenario: Remove events from activity log
	Given logged in user is on the 'Activity Log' page
	When user deletes first '3' items on table
	Then the items should be removed