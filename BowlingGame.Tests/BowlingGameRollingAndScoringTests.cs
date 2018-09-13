using System;
using NUnit.Framework;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class BowlingGameRollingAndScoringTests
    {
        #region Private Variables

        private Game _game;

        #endregion

        #region Fixture Setup / Tear Down

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [TearDown]
        public void TearDown()
        {
            _game = null;
        }

        #endregion

        #region Fixture Test Methods

        [Test]
        public void Test_game_player_scores_all_gutter_balls()
        {
            RollByMultipleAndPinsDown(20, 0);

            Assert.AreEqual(0, _game.Score());

        }

        [Test]
        public void Test_game_player_scores_all_ones()
        {
            RollByMultipleAndPinsDown(20, 1);

            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void Test_game_player_rolls_one_spare()
        {
            RollSpare();
            _game.Roll(3);
            RollByMultipleAndPinsDown(17, 0);

            Assert.AreEqual(16, _game.Score());
        }

        [Test]
        public void Test_game_player_rolls_one_strike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollByMultipleAndPinsDown(16, 0);

            Assert.AreEqual(24, _game.Score());
        }

        [Test]
        public void Test_game_player_plays_perfect_300_game()
        {
            RollByMultipleAndPinsDown(12, 10);

            Assert.AreEqual(300, _game.Score());
        }

        [Test]
        public void Test_game_player_trys_to_roll_too_many_balls()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => RollByMultipleAndPinsDown(22, 1));
            Assert.That(ex.Message, Is.EqualTo("Index was outside the bounds of the array."));
        }

        #endregion

        #region Fixture Helper/Shared Methods

        private void RollByMultipleAndPinsDown(int rolls, int pinsDown)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pinsDown);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        #endregion
    }
}
