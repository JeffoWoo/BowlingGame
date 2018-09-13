using System;

namespace BowlingGame
{
    public class Game
    {
        #region Private Variables

        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pinsDown)
        {
            try
            {
                _rolls[_currentRoll++] = pinsDown;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Instance Methods

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if(FrameIsStrike(roll))
                {
                    score += GetScoreForStrikeFrame(roll);
                    roll++;
                }
                else if (FrameIsSpare(roll))
                {
                    score += GetScoreForSpareFrame(roll);
                    roll += 2;
                }
                else
                {
                    score += GetScoreForRegularFrame(roll);
                    roll += 2;
                }
            }

            return score;
        }

        #endregion

        #region Instance Helper Methods

        private bool FrameIsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }

        private bool FrameIsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }

        private int GetScoreForRegularFrame(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }

        private int GetScoreForSpareFrame(int roll)
        {
            return 10 + _rolls[roll + 2];
        }

        private int GetScoreForStrikeFrame(int roll)
        {
            return 10 + _rolls[roll + 1] + _rolls[roll + 2];
        }

        #endregion
    }
}
