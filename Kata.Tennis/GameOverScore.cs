namespace Kata.Tennis
{
    public class GameOverScore : PlayerScoreBase
    {
        public override bool GameOver => true;

        public Player Player { get; }

        public GameOverScore(Player player)
        {
            Player = player;
        }

        public override PlayerScoreBase PointFor(Player wins) => this;

        public override string ToString() => $"{Player} wins!";
    }
}