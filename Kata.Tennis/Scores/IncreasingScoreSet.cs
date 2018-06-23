﻿using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis.Scores
{
    public class IncreasingScoreSet : Score
    {
        public override bool IsWinner => false;
        private readonly IEnumerable<Score> _scores;

        private static IEnumerable<Score> CreateInnerScores(string score) =>
            score.Split(PointsSeparator)
                 .Select((points, index) =>
                            new IncreasingScore((Player)index, int.Parse(points)));

        public IncreasingScoreSet(string score) : this(CreateInnerScores(score)) {}
        private IncreasingScoreSet(IEnumerable<Score> scores)
        {
            _scores = scores;
        }

        public override string Format() =>
            _scores.Select(x => x.Format())
                   .JoinToString($"{PointsSeparator}");

        public override Score PointFor(Player wins)
        {
            var nextScores  = _scores.Select(x => x.PointFor(wins)).ToList();
            var winnerScore = nextScores.FirstOrDefault(x => x.IsWinner);
            return winnerScore ?? new IncreasingScoreSet(nextScores);
        }
    }
}