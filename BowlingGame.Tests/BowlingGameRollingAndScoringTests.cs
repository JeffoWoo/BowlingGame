using NUnit.Framework;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class BowlingGameRollingAndScoringTests
    {
        [Test]
        public void Test_game_player_scores_all_gutter_balls()
        {
            var game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(0, game.Score());

        }

        [Test]
        public void Test_game_player_scores_all_ones()
        {
            var game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(20, game.Score());
        }
    }
}
