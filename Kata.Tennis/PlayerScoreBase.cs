using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis
{
    public abstract class PlayerScoreBase
    {
        public abstract bool GameOver { get; }
        public abstract PlayerScoreBase PointFor(Player wins);

        public static IEnumerable<PlayerScoreBase> Parse(string score) =>
            score.Split(':')
                 .Select(int.Parse)
                 .Select((points, index) => new PlayerScore((Player) index, points));
    }
}