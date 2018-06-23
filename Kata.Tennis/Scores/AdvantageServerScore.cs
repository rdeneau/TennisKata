namespace Kata.Tennis.Scores
{
    public class AdvantageServerScore : EndingScore
    {
        public AdvantageServerScore() : base($"{A}:{MaxPoint}") { }

        protected override Score PointForServer   => new WinnerScore(Player.server);
        protected override Score PointForReceiver => new DeuceScore();
    }
}