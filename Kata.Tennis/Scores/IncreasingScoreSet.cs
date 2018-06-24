using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis.Scores
{
    public class IncreasingScoreSet : Score
    {
        public override bool IsWinner => false;
        private readonly IEnumerable<Score> _scores;

        private static Score Create(IEnumerable<Score> scores)
        {
            Score result = new IncreasingScoreSet(scores);
            Score deuce  = new DeuceScore();
            return result.Value == deuce.Value ? deuce : result;
        }

        private static IEnumerable<Score> CreateInnerScores(string score) =>
            score.Split(PointsSeparator)
                 .Select((points, index) =>
                            new IncreasingScore((Player)index, int.Parse(points)));

        public IncreasingScoreSet(string score) : this(CreateInnerScores(score)) {}
        private IncreasingScoreSet(IEnumerable<Score> scores)
        {
            _scores = scores;
        }

        public override string Value => _scores.Select(x => x.Value)
            .JoinToString($"{PointsSeparator}");

        public override Score PointFor(Player wins)
        {
            var nextScores  = _scores.Select(x => x.PointFor(wins)).ToList();
            var winnerScore = nextScores.FirstOrDefault(x => x.IsWinner);
            return winnerScore ?? Create(nextScores);
        }
    }
}