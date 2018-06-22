using System;

namespace Kata.Tennis
{
    public class IncreasingScore : Score
    {
        public override bool IsGameWon => false;
        public Player Player { get; }
        private int Points { get; }
        private const int MaxPoint = 40;

        public IncreasingScore(Player player, int points)
        {
            Player = player;
            Points = points;
        }

        public override string Format() => Points.ToString("0");

        public override Score PointFor(Player wins)
        {
            if (Player != wins)
                return this;

            if (Points == MaxPoint)
                return new GameWonScore(Player);

            return new IncreasingScore(Player, NextPoints());
        }

        private int NextPoints() => Math.Min(Points + 15, MaxPoint);
    }
}