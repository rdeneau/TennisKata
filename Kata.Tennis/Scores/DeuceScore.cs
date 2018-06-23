namespace Kata.Tennis.Scores
{
    public class DeuceScore : EndingScore
    {
        public DeuceScore() : base($"{MaxPoint}:{MaxPoint}") { }

        protected override Score PointForServer   => new AdvantageServerScore();
        protected override Score PointForReceiver => new AdvantageReceiverScore();
    }
}