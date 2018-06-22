using System;
using NFluent;
using TechTalk.SpecFlow;
using Xunit;

namespace Kata.Tennis.Tests
{
    [Binding]
    public class GameScoreSteps
    {
        private readonly Game game = new Game();

        [Given(@"the score is (.*)")]
        public void GivenScoreLoveAll(string score)
        {
            game.Parse(score);
        }
    
        [When(@"the (.*) wins a point")]
        public void WhenAPlayerWinsAPoint(Player player)
        {
            game.PointFor(player);
        }

        [Then(@"the score is (.*)")]
        public void ThenTheScoreIs(string expectedScore)
        {
            Check.That(game.Score).IsEqualTo(expectedScore);
        }
    }
}
