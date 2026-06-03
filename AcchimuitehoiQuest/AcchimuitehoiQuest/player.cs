namespace AcchimuitehoiQuest
{
    public class player
    {
        public int HP { get; set; }
        public int JankenHand { get; set; }
        public int Direction { get; set; }

        public player()
        {
            HP = 3;
            JankenHand = 0;
            Direction = 0;
        }
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
            }
        }

        public bool IsAlive()
        {
            if (HP > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
