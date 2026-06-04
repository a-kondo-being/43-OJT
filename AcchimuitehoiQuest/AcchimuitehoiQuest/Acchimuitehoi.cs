using System;
using System.Collections.Generic;

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
        public enum Direction
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }
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
