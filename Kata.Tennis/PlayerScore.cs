using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis
{
    public class PlayerScore : PlayerScoreBase
    {
        public override bool GameOver => false;

        public Player Player { get; }
        private int Points { get; }

        public PlayerScore(Player player, int points)
        {
            Player = player;
            Points = points;
        }

        public override PlayerScoreBase PointFor(Player wins)
        {
            if (Player != wins)
                return this;

            if (Points == 40)
                return new GameOverScore(Player);

            return new PlayerScore(Player, NextPoints());
        }

        private int NextPoints() => Points == 30 ? 40 : Points + 15;

        public override string ToString() => Points.ToString("0");
    }
}