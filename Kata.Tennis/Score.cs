using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis
{
    public abstract class Score
    {
        public abstract bool IsGameWon { get; }
        public abstract string Format();
        public abstract Score PointFor(Player wins);

        public static IEnumerable<Score> Parse(string score) =>
            score.Split(':')
                 .Select(int.Parse)
                 .Select((points, index) => new IncreasingScore((Player) index, points));
    }
}