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

- [*Factory*](https://en.wikipedia.org/wiki/Factory_method_pattern):
  - `Score.Parse()`
  - `IncreasingScoreSet.Create()`
- [*State*](https://en.wikipedia.org/wiki/State_pattern):
  - `score.PointFor()` returns the next score, possibly a new type to respond to a different behavior. E.g.:
    - `IncreasingScoreSet(40:30)` => `Deuce` (40:40)
    - `Deuce` => `AdvantageServerScore`
- [*Template method pattern*](https://en.wikipedia.org/wiki/Template_method_pattern):
  - `EndingScore` is an abstract class. It declares the properties `PointForServer` and `PointForReceiver` as abstract in order to be defined in derived classes. These properties are used in the base method `PointFor()`.
- [*Composite*](https://en.wikipedia.org/wiki/Composite_pattern):
  - `IncreasingScoreSet` acts as a single score but contains both server and receiver scores in points.
  - All other scores are modeled with a single player:
    - The server during "ending scores" (deuce, advantages)
    - The winner of the game
- *Immutability*: scores are not muted - new scores are returned.

## Notes

`Score` is an abstract class instead of an interface in order to provide the static factory `Parse` and some protected constants (`MaxPoint`...) used by its derived classes.
