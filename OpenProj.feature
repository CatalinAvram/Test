Feature: OpenProject
    Given that I want to start traslation work
	As a Translation Studio user
	I want to open a project
@mytag
Scenario: Open a project
	Given I have successfully loaded Translation Studio
	When I press File tab
	And I press Open Project
	And I insert Project Name
	And I press Open
	Then The project should appear in the projects list
