namespace Kata.Tennis
{
    public class GameWonScore : Score
    {
        public override bool IsGameWon => true;

        public Player Player { get; }

        public GameWonScore(Player player)
        {
            Player = player;
        }

        public override Score PointFor(Player wins) => this;

        public override string Format() => $"{Player} wins!";
    }
}