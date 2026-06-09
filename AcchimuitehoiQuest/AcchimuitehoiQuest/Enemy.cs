// 【完了基準クリア】エネミークラスの実装
using System.Drawing;
namespace AcchimuitehoiQuest
{

    public class Enemy
    {
        // --- プロパティの定義 ---
        public string Name { get; set; }
        public int HP { get; set; }
        public int TargetDirection { get; set; }
        public Image ImageFront { get; set; }
        public Image ImageUp { get; set; }
        public Image ImageDown { get; set; }
        public Image ImageLeft { get; set; }
        public Image ImageRight { get; set; }


        public static Enemy CreateSlime()                            // ステージ1用：スライムを作成して返す
        {
            Enemy slime = new Enemy();
            slime.Name = "スライム";
            slime.HP = 1;
            slime.TargetDirection = 0;                               
            slime.ImageFront = Properties.Resources.スライム正面_removebg_preview;
            slime.ImageUp = Properties.Resources.上透過_Photoroom;
            slime.ImageDown = Properties.Resources.下透過_Photoroom;
            slime.ImageLeft = Properties.Resources.左透過_Photoroom;
            slime.ImageRight = Properties.Resources.右;
            return slime;
        }


        public static Enemy CreateGolem()                            // ステージ2用：ゴブリンを作成して返す
        {
            Enemy golem = new Enemy();
            golem.Name = "ゴーレム";
            golem.HP = 2;
            golem.TargetDirection = 2;
            golem.ImageFront = Properties.Resources.ゴーレム正面_removebg_preview;
            golem.ImageUp = Properties.Resources.ゴーレム_上_removebg_preview; 
            golem.ImageDown = Properties.Resources.ゴーレム_下_removebg_preview;
            golem.ImageLeft = Properties.Resources.ゴーレム_左__removebg_preview;
            golem.ImageRight = Properties.Resources.ゴーレム_右_removebg_preview;
            return golem;
        }


        public static Enemy CreateDemonKing()                          // ステージ3用：魔王を作成して返す
        {
            Enemy demon = new Enemy();
            demon.Name = "魔王";
            demon.HP = 3;
            demon.TargetDirection = 1;
            demon.ImageFront = Properties.Resources.魔王正面_removebg_preview;
            demon.ImageUp = Properties.Resources.魔王上向き_removebg_preview;
            demon.ImageDown = Properties.Resources.魔王下向き_removebg_preview;
            demon.ImageLeft = Properties.Resources.魔王左向き_removebg_preview;
            demon.ImageRight = Properties.Resources.魔王右向き_removebg_preview;
            return demon;
        }
    }
}