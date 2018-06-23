using System.Linq;

namespace Kata.Tennis.Scores
{
    public abstract class Score
    {
        public abstract bool IsWinner { get; }
        public abstract string Format();
        public abstract Score PointFor(Player wins);

        protected const string Advantage = "A";
        protected const char PointsSeparator = ':';
        protected const int MaxPoint = 40;

        public static Score Parse(string score) =>
            new Score[]
            {
                new DeuceScore(),
                new AdvantageReceiverScore(),
                new AdvantageServerScore()
            }
            .FirstOrDefault(x => x.Format() == score)
            ?? new IncreasingScoreSet(score);
    }
}