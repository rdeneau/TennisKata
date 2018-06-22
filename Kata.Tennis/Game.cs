using System.Linq;

namespace Kata.Tennis
{
    public class Game
    {
        private PlayerScoreBase receiver;
        private PlayerScoreBase server;

        private PlayerScoreBase[] PlayerScores => new[] {server, receiver};

        public void Parse(string score)
        {
            var result = PlayerScoreBase.Parse(score).ToArray();
            server   = result[0];
            receiver = result[1];
        }

        public void PointFor(Player player)
        {
            server   = server  .PointFor(player);
            receiver = receiver.PointFor(player);
        }

        public string Score()
        {
            var winner = PlayerScores.FirstOrDefault(score => score.GameOver);
            return winner?.ToString() ?? $"{server}:{receiver}";
        }
    }
}
