# http://agilekatas.co.uk/katas/tennis-kata

Feature: Tennis Game Score
	As a library user
	I want the score to increase when a player wins a point
	So that I can display the current score correctly

Scenario Outline: Winning a point changes the score
	Given the score is <initial_score>
	When the <player> wins the point
	Then the score is <expected_score>

	Examples:
	| initial_score | player   | expected_score |
	# Increasing scores
	| 0:0           | server   | 15:0           |
	| 15:0          | receiver | 15:15          |
	| 15:15         | receiver | 15:30          |
	| 15:30         | server   | 30:30          |
	| 30:30         | server   | 40:30          |
	| 30:40         | server   | 40:40          |
	| 30:0          | server   | 40:0           |
	# Game won from an increasing score
	| 40:0          | server   | server wins!   |
	| 40:30         | server   | server wins!   |
	| 15:40         | receiver | receiver wins! |
	# Ending scores
	| 40:40         | server   | A:40           |
	| 40:A          | server   | 40:40          |
	| 40:40         | receiver | 40:A           |
	| A:40          | receiver | 40:40          |
	# Game won from an ending score
	| A:40          | server   | server wins!   |
	| 40:A          | receiver | receiver wins! |
