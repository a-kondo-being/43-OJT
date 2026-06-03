using System;
using System.Collections.Generic;

namespace AcchimuitehoiQuest
{
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
            List<Direction> otherDirections = new List<Direction>
            {
                Direction.Up,
                Direction.Down,
                Direction.Left,
                Direction.Right
            };
            otherDirections.Remove(easyDirection);
            int randomIndex = random.Next(0, 3);
            return otherDirections[randomIndex];
        }
        public bool IsSuccess(Direction playerDirection, Direction enemyDirection)
        {
            return playerDirection == enemyDirection;
        }
    }
}
