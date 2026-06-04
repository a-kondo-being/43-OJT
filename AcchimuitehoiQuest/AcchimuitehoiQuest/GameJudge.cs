using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcchimuitehoiQuest
{
    public class GameJudge
    {
        public string Check(int playerHP, int enemyHP, int CurrentStage)
        {
            if (playerHP <= 0)
            {
                return "ゲームオーバー";
            }
            
            if (enemyHP <= 0)
            {
                if (CurrentStage >= 3)
                {
                    return "ゲームクリア";
                }
                else
                {
                    return "ステージクリア";
                }
            }
            return "バトル";
        }
    }
}