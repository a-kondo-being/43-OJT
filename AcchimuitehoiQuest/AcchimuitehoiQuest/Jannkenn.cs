using System;

namespace AcchiMuitehoiQuest
{
    public class Jannkenn
    {
        private Random random = new Random();

        public const int HandGu = 0;
        public const int HandChoki = 1;
        public const int HandPa = 2;

        public const int Draw = 0;
        public const int Win = 1;
        public const int Lose = 2;

        public int GetEnemyHand()
        {
            return random.Next(0, 3);
        }

        public int Judge(int enemyhand, int playerhand)
        {
            if ((playerhand == HandGu && enemyhand == HandChoki) ||
                (playerhand == HandChoki && enemyhand == HandPa) ||
                (playerhand == HandPa && enemyhand == HandGu))
            {
                return Win;
            }
            else if ((playerhand == HandGu && enemyhand == HandPa) ||
                     (playerhand == HandChoki && enemyhand == HandGu) ||
                     (playerhand == HandPa && enemyhand == HandChoki))
            {
                return Lose;
            }
            else
            {
                return Draw;
            }
        }
    }
}




