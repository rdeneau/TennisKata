namespace Kata.Tennis.Scores
{
    public abstract class EndingScore : Score
    {
        private readonly string _score;
        public override bool IsWinner => false;
        public Player Player => Player.server;

        protected EndingScore(string score)
        {
            _score = score;
        }

        public override string Format() => _score;

        public override Score PointFor(Player wins) => Player == wins ? PointForServer : PointForReceiver;

        protected abstract Score PointForServer { get; }
        protected abstract Score PointForReceiver { get; }
    }
}