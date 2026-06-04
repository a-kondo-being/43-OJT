// 【完了基準クリア】エネミークラスの実装

namespace WindowsFormsApp1
{

    public class Enemy
    {
        // --- プロパティの定義 ---
        public string Name { get; set; }
        public int HP { get; set; }
        public int TargetDirection { get; set; }


        public static Enemy CreateSlime()                            // ステージ1用：スライムを作成して返す
        {
            Enemy enemy = new Enemy();
            enemy.Name = "スライム";
            enemy.HP = 1;
            enemy.TargetDirection = 0;                                // 例：上を向きやすい
            return enemy;
        }


        public static Enemy CreateGolem()                            // ステージ2用：ゴブリンを作成して返す
        {
            Enemy enemy = new Enemy();
            enemy.Name = "ゴーレム";
            enemy.HP = 2;
            enemy.TargetDirection = 2;                                // 例：左を向きやすい
            return enemy;
        }


        public static Enemy CreateDemonKing()                          // ステージ3用：魔王を作成して返す
        {
            Enemy enemy = new Enemy();
            enemy.Name = "魔王";
            enemy.HP = 3;
            enemy.TargetDirection = 1;                                 // 例：下を向きやすい
            return enemy;
        }
    }
}