# http://agilekatas.co.uk/katas/tennis-kata

Feature: Tennis Game Score
	As a library user
	I want the score to increase when a player wins a point
	So that I can display the current score correctly

Scenario: Server wins a point on love-all
	Given the score is 0:0
	When the server wins a point
	Then the score is 15:0

Scenario: Receiver wins a point on fifteen-all
	Given the score is 15:15
	When the receiver wins a point
	Then the score is 15:30
