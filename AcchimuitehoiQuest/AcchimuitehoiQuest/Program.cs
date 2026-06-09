using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // スタートボタンなどが押されたときの処理
            StageManager stageManager = new StageManager();

            // SetupNextStage()を呼ぶと、CurrentStageNumberが1になり、スライムがCurrentEnemyに入る！
            stageManager.SetupNextStage();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BattleForm(stageManager));
        }
    }
}
