using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis
{
    public class Game
    {
        private IEnumerable<Score> _scores;

        public void Parse(string score)
        {
            _scores = Tennis.Score.Parse(score);
        }

        public void PointFor(Player wins)
        {
            _scores = _scores.Select(player => player.PointFor(wins));
        }

        public string Score() => _scores
            .Where(score => score.IsGameWon)
            .DefaultsIfEmpty(_scores)
            .Select(score => score.Format())
            .JoinToString(":");
    }
}
