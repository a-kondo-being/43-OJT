using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;



namespace WindowsFormsApp1
    {
    
        public class StageManager
        {
              public int CurrentStageNumber { get; set; } = 0;               // ① 現在のステージ番号を記憶するプロパティ（初期値は0）

        
              public Enemy CurrentEnemy { get; set; }                        // 現在戦っている敵のデータを入れておくプロパティ

       
        private Random random = new Random();                               // 乱数（ランダム）を使うための準備

            
            public void SetupNextStage()                                    // 次のステージに進むときの処理（台本）
        {
                
                CurrentStageNumber++;

                // ② ステージ番号に合わせて、あなたが作った敵データを呼び出す
                if (CurrentStageNumber == 1)
                {
                    CurrentEnemy = Enemy.CreateSlime();
                }
                else if (CurrentStageNumber == 2)
                {
                    CurrentEnemy = Enemy.CreateGolem(); 
                }
                else if (CurrentStageNumber == 3)
                {
                    CurrentEnemy = Enemy.CreateDemonKing();
                }

               
                CurrentEnemy.TargetDirection = random.Next(0, 4);                // ③ 呼び出した敵の「向きやすい方向」をランダム（0〜3）で上書きする
        }
        }
    }
