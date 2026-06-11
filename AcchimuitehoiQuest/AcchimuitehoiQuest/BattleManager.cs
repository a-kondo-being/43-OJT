using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcchimuitehoiQuest;

namespace AcchimuitehoiQuest
{
    public class BattleManager
    {
        public int PlayerHP { get; set; }          // プロパティの定義
        public Enemy CurrentEnemy { get; set; }        // 現在戦っている敵のデータを入れておくプロパティ
        public string CurrentPhase { get; set; }

        public BattleManager()
        {
            this.PlayerHP = 300;                      // プレイヤーのHPは初期値3
            this.CurrentPhase = "じゃんけん"; // 初期フェーズはじゃんけん
        }
        public void SetupEnemy(Enemy enemy)        // 戦いを始めるときの処理（台本）
        {
            this.CurrentEnemy = enemy;              // 引数で渡された敵のデータをプロパティに入れる
        }


        public void OnJankenLose()
        {
            this.PlayerHP--;                      // じゃんけんに負けたときはプレイヤーのHPを1減らす
            this.CurrentPhase = "じゃんけん"; // じゃんけんやり直し
        }

        public void OnJankenwin()
        {
            this.CurrentPhase = "あっち向いてホイ"; // じゃんけんに勝ったときはフェーズを「あっち向いてホイ」にする
        }

        public void OnAcchimuiteHoiResult(bool isSuccess)
        {
            // 【ガード節1】失敗した場合は、じゃんけんに戻してすぐ処理を終了する
            if (!isSuccess)
            {
                this.CurrentPhase = "じゃんけん";
                return;
            }

            // 【ガード節2】敵がセットされていない異常事態なら、エラーを防ぐため処理を抜ける
            if (this.CurrentEnemy == null)                               
            {
                return;
            }

            // --- ここから下は「成功した」かつ「敵が存在する」ことが保証された処理 ---

            
            this.CurrentEnemy.HP--;         // 敵のHPを1減らす
           
            // もし敵のHPがまだ残っていれば、じゃんけんフェーズに戻す
            if (this.CurrentPhase != "ステージクリア")
            {
                this.CurrentPhase = "じゃんけん";
            }
        }

      
    }
}

