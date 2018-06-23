# Tennis Kata

## Details

See [Agile Katas](http://agilekatas.co.uk/katas/tennis-kata)

## Domains to work on

- **TDD** throught **BDD** scenarios, with *Gerkhin*, implemented with *SpecFlow* in this C# project
- **OOP**: discover the different kind of scores:
  - *Increasing scores*: each point won increases the score in points of the player that has won this point.
  - *Ending scores*: scores at the end of the game, after that both players have reached 40 points. Hence, scores alternate between deuce and advantage for one player.
  - *Winner score*: mentionning the player that has won the game.

## Patterns discovered

- *Factory*: `Score.Parse()`
- *State*: `score.PointFor()` returns the next score
- *Composite*:
  - `IncreasingScoreSet` acts as a single score but contains both server and receiver scores in points.
  - All other scores are modeled with a single player:
    - The server during "ending scores" (deuce, advantages)
    - The winner of the game
- *Immutability*: scores are not muted - new scores are returned.