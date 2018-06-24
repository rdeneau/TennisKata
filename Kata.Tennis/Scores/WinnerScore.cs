namespace Kata.Tennis.Scores
{
    public class WinnerScore : Score
    {
        public override bool IsWinner => true;
        public Player Player { get; }

        public WinnerScore(Player player)
        {
            Player = player;
        }

        public override Score PointFor(Player wins) => this;

        public override string Value => $"{Player} wins!";
    }
}