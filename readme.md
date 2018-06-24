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

- `Score` is an abstract class instead of an interface in order to provide the static factory `Parse` and some protected constants (`MaxPoint`...) used by its derived classes. To respect the [DIP](https://en.wikipedia.org/wiki/Dependency_inversion_principle), we should put `Score` in a distinct project, for instance `Kata.Tennis.Contracts`, in order for the consumer to depend on this last project and not on the project defining the implementation.
- `WinnerScore.PointFor()` does not throw an exception but just returns `this` because an exception means a technical issue. But here it's a functional edge case. Exception is not suitable in this case. In that way it respects the [LSP](https://en.wikipedia.org/wiki/Liskov_substitution_principle). An alternate option could be to use an `Option` (inspired from F#) returning `None`. But it's an overkill here because there's no features related to this behavior.
- Scores are not modeled as ValueObjects: they lacks equality members. It's for 2 reasons:
  - A generic guideline when modeling ValueObjects is not to rely on inheritance. A ValueObject must be sealed otherwise equality cannot be balanced and we could have `t == s` but `s != t` where `S extends T` because of additional members in `S` participating in the equality.
  - In our model, we have 2 possibilities to model "40:40": `IncreasingScoreSet(40, 40)` or `Deuce`. They should not be equaled.
- Eventhought we're using BDD, there's no double TDD loop: a big "Acceptance Test" loop and several smaller "Unit Tests" loops inside. It's because we didn't feel the need to do that way. Time on Red is longer but there are no redundant tests: using a scenario outline enables us to cover all cases.

## TO DO

- [] UML class diagram
- [] Score label (e.g. "fifteen-love")
  - IncreasingScore: create specialized classes? Or add constructor parameters `string label` and `int nextPoints` to avoid computation of next score (0, 15, 30, 40 /!\) currently handled with a trick: min(40, points + 15)
- [] All lots of classes => try a functional approach
