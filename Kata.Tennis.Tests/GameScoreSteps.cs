using NFluent;
using TechTalk.SpecFlow;

namespace Kata.Tennis.Tests
{
    [Binding]
    public class GameScoreSteps
    {
        private readonly Game _game = new Game();

        [Given(@"the score is (.*)")]
        public void GivenScoreLoveAll(string score)
        {
            _game.Parse(score);
        }
    
        [When(@"the (.*) wins a point")]
        public void WhenAPlayerWinsAPoint(Player player)
        {
            _game.PointFor(player);
        }

        [Then(@"the score is (.*)")]
        public void ThenTheScoreIs(string expectedScore)
        {
            Check.That(_game.Score()).IsEqualTo(expectedScore);
        }
    }
}
