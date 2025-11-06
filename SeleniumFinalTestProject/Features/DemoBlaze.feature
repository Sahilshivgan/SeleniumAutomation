Feature: DemoBlaze

Feature: Demoblaze Shopping Flow

Background:
	Given I navigate to the Demoblaze website

Scenario Outline: Sign up, login, and add laptop to cart
	When I open the Sign Up modal with "<username>" and password "<password>"
	Then I should see a signup success message
	

	When I open the Login modal with "<username>" and password "<password>"
	Then I should see the user logged in

	
	When I click on "Laptops" category on home page
	And I select the laptop "<product>" and add it to the cart
	Then I should see a confirmation message
	And the laptop should appear in the cart

	

Examples:
	| username          | password  | product      |
	| sahuyuguyjb12erssr | test@5444 | Sony vaio i5 |
