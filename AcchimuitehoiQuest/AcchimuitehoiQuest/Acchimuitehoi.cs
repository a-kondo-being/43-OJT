using System;

namespace AcchimuitehoiQuest
{
    public enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }
    public class AcchimuitehoiLogic
    {
        private Random random = new Random();

        public Direction DetermineEnemyDirection(Direction easyDirection)
        {
            int randomValue = random.Next(1, 101);

            if (randomValue <= 40)
            {
                return easyDirection;
            }
            Direction result;
            do
            {
                int randomNumber = random.Next(0, 4);
                result = (Direction)randomNumber;
            }
            while (result == easyDirection);

            return result;
        }
        public bool IsSuccess(Direction playerDirection, Direction enemyDirection)
        {
            return playerDirection == enemyDirection;
        }
    }
}
