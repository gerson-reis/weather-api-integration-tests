Feature: Verify if application is on work

Scenario: Call check endpoint
	Given the application is on working
	And the check endpoint is called
	Then the response status should be Ok