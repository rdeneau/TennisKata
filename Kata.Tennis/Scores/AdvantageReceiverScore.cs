﻿namespace Kata.Tennis.Scores
{
    public class AdvantageReceiverScore : EndingScore
    {
        public AdvantageReceiverScore() : base($"{MaxPoint}:{A}") { }

        protected override Score PointForServer   => new DeuceScore();
        protected override Score PointForReceiver => new WinnerScore(Player.receiver);
    }
}