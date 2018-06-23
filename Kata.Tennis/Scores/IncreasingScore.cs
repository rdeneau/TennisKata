using System;

namespace Kata.Tennis.Scores
{
    public class IncreasingScore : Score
    {
        public override bool IsWinner => false;
        public Player Player { get; }
        private int Points { get; }

        public IncreasingScore(Player player, int points)
        {
            Player = player;
            Points = points;
        }

        public override string Format() => $"{Points:0}";

        public override Score PointFor(Player wins)
        {
            if (Player != wins)
                return this;

            if (Points == MaxPoint)
                return new WinnerScore(Player);

            return new IncreasingScore(Player, NextPoints());
        }

        private int NextPoints() => Math.Min(Points + 15, MaxPoint);
    }
}