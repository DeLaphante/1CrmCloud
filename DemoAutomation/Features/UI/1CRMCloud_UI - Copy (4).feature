Feature: 1CRMCloud_UI - Copy (4)

Background: Navigate to login page
	Given user is on the homepage
	And user with the following details logs in:
		| Property | Value |
		| Username | admin |
		| Password | admin |


Scenario Outline: Create contact
	Given logged in user is on the 'Contacts' page
	When user creates a contact
	Then created contact is successfully added
Examples:
	| Test |
	| 1    |
	| 2    |
	| 3    |
	| 4    |
	| 5    |
	| 6    |
	| 7    |
	| 8    |
	| 9    |
	| 10   |
	| 12   |
	| 13   |
	| 14   |
	| 15   |
	| 16   |
	| 17   |
	| 18   |
	| 19   |
	| 20   |
	| 21   |


Scenario Outline: Run report
	Given logged in user is on the 'Reports' page
	When user runs a 'Project Profitability' report
	Then some results are returned
Examples:
	| Test |
	| 1    |
	| 2    |
	| 3    |
	| 4    |
	| 5    |
	| 6    |
	| 7    |
	| 8    |
	| 9    |
	| 10   |
	| 12   |
	| 13   |
	| 14   |
	| 15   |
	| 16   |
	| 17   |
	| 18   |
	| 19   |
	| 20   |
	| 21   |


Scenario Outline: Remove events from activity log
	Given logged in user is on the 'Activity Log' page
	When user deletes first '3' items on table
	Then the items should be removed
Examples:
	| Test |
	| 1    |
	| 2    |
	| 3    |
	| 4    |
	| 5    |
	| 6    |
	| 7    |
	| 8    |
	| 9    |
	| 10   |
	| 12   |
	| 13   |
	| 14   |
	| 15   |
	| 16   |
	| 17   |
	| 18   |
	| 19   |
	| 20   |
	| 21   |