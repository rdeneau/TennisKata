using Kata.Tennis.Scores;
using NFluent;
using TechTalk.SpecFlow;

namespace Kata.Tennis.Tests
{
    [Binding]
    public class GameScoreSteps
    {
        private string _score;
        private Player _wins;

        [Given(@"the score is (.*)")]
        public void GivenInitialScore(string score)
        {
            _score = score;
        }
    
        [When(@"the (.*) wins the point")]
        public void WhenThePlayerWinsThePoint(Player player)
        {
            _wins = player;
        }

        [Then(@"the score is (.*)")]
        public void ThenTheScoreIs(string expectedScore)
        {
            var result = Score.Parse(_score).PointFor(_wins);
            Check.That(result.Value).IsEqualTo(expectedScore);
        }
    }
}
