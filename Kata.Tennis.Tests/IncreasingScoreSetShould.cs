using Kata.Tennis.Scores;
using NFluent;
using Xunit;

namespace Kata.Tennis.Tests
{
    public class IncreasingScoreSetShould
    {
        [Fact]
        public void SwitchToDeuce()
        {
            var sut = Score.Parse("40:30");
            var result = sut.PointFor(Player.receiver);
            Check.That(sut).IsInstanceOfType(typeof(IncreasingScoreSet));
            Check.That(result).IsInstanceOfType(typeof(DeuceScore));
        }
    }
}
