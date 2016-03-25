Feature: TestMain
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers 678
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Remove two numbers 678
	Given I have entered 33 into the calculator
	And I have entered 90 into the calculator
	When I press minus
	Then the result should be 120 on the screen
