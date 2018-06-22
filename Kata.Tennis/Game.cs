using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis
{
    public class Game
    {
        private PlayerScore receiver;
        private PlayerScore server;

        public void Parse(string score)
        {
            var result = PlayerScore.Parse(score).ToArray();
            server   = result[0];
            receiver = result[1];
        }

        public void PointFor(Player player)
        {
            server   = server  .PointFor(player);
            receiver = receiver.PointFor(player);
        }

        public string Score => $"{server}:{receiver}";
    }

    public class PlayerScore
    {
        private readonly Player player;
        private readonly int points;

        public PlayerScore(Player player, int points)
        {
            this.player = player;
            this.points = points;
        }

        public static IEnumerable<PlayerScore> Parse(string score)
        {
            return score.Split(':')
                        .Select(int.Parse)
                        .Select((points, index) => new PlayerScore((Player) index, points));
        }

        public PlayerScore PointFor(Player wins)
        {
            return player == wins ? new PlayerScore(player, points + 15) : this;
        }

        public override string ToString() => points.ToString("0");
    }
}
