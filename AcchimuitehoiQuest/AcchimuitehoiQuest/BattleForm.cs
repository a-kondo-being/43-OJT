using AcchiMuitehoiQuest;
using System;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class BattleForm : Form
    {
        // =========================================================
        // 1. バトルで使う「3つの管理ロボット」の準備
        // =========================================================
        BattleManager manager = new BattleManager();
        Jannkenn janken = new Jannkenn();
        AcchimuitehoiLogic hoiLogic = new AcchimuitehoiLogic();
        bool isAiko = false;

        // ★変更：Enemy単体ではなく、StageManagerごと受け取る変数を用意する
        private StageManager currentStageManager;

        // ★変更：引数を StageManager にする
        public BattleForm(StageManager stageManager)
        {
            InitializeComponent();

            // 渡されたステージ管理ロボットを保存しておく
            currentStageManager = stageManager;
        }

        // =========================================================
        // 2. 画面が開いた瞬間（エンカウント時）の初期化処理
        // =========================================================
        private async void BattleForm_Load(object sender, EventArgs e)
        {
            manager.SetupEnemy(currentStageManager.CurrentEnemy);

            lblMessage.Text = manager.CurrentEnemy.Name + "が現れた！";

            HandPanel.Visible = false;
            PanelPointing.Visible = false;
            EnemyHand.Visible = false;

            PlayerHP1.Visible = (manager.PlayerHP >= 1);
            PlayerHP2.Visible = (manager.PlayerHP >= 2);
            PlayerHP3.Visible = (manager.PlayerHP >= 3);
            SlimeHpPanel.Visible = true;
            GolemHpPanel.Visible = false;
            DemonHpPanel.Visible = false;
            SlimeHP.Visible = (manager.CurrentEnemy.HP >= 1);

            await System.Threading.Tasks.Task.Delay(900);
            lblMessage.Text = "じゃんけん…";

            UpdateDisplay();

            EnemyHand.Visible = false;

            lblMessage.Text = "じゃんけん…";
        }

        // =========================================================
        // 3. じゃんけんボタンが押されたときの処理
        // =========================================================
        private void PlayerHandGu_Click(object sender, EventArgs e)
        {
            ExecuteJanken(Jannkenn.HandGu);
        }

        private void PlayerHandChoki_Click(object sender, EventArgs e)
        {
            ExecuteJanken(Jannkenn.HandChoki);
        }

        private void PlayerHandPa_Click(object sender, EventArgs e)
        {
            ExecuteJanken(Jannkenn.HandPa);
        }

        private async void ExecuteJanken(int playerHand)
        {

            if (isAiko)
            {
                lblMessage.Text = "しょ！";
            }
            else
            {
                lblMessage.Text = "ほい！";
            }

            HandPanel.Enabled = false;
            await System.Threading.Tasks.Task.Delay(500);

            int enemyHand = janken.GetEnemyHand();

            // =========================================================
            // ★追加：敵の手（乱数）に合わせて、EnemyHandの画像を入れ替える
            // =========================================================
            if (enemyHand == Jannkenn.HandGu)
            {
                EnemyHand.BackgroundImage = Properties.Resources.グー; // ←グーの画像名
            }
            else if (enemyHand == Jannkenn.HandChoki)
            {
                EnemyHand.BackgroundImage = Properties.Resources.チョキ; // ←チョキの画像名
            }
            else if (enemyHand == Jannkenn.HandPa)
            {
                EnemyHand.BackgroundImage = Properties.Resources.パー; // ←パーの画像名
            }
            UpdateDisplay();
            HandPanel.Enabled = false;
            await System.Threading.Tasks.Task.Delay(900);

            int result = janken.Judge(enemyHand, playerHand);

            if (result == Jannkenn.Draw)
            {
                isAiko = true; // ★追加：あいこになったのでフラグをON
                lblMessage.Text = "あいこで…";
            }
            else if (result == Jannkenn.Win)
            {
                isAiko = false; // ★追加：決着がついたのでフラグをリセット
                lblMessage.Text = "じゃんけんに勝った！\nあっち向いて…";
                manager.OnJankenwin();
            }
            else if (result == Jannkenn.Lose)
            {
                isAiko = false; // ★追加：決着がついたのでフラグをリセット
                manager.OnJankenLose();
                if (manager.PlayerHP <= 0)
                {
                    lblMessage.Text = "じゃんけんに負けた！";
                }
                else
                {
                    lblMessage.Text = "じゃんけんに負けた！ダメージを受けた！\nもう一度じゃんけん…";
                }
            }

            // 判定が終わったのでパネルを押せるように戻す
            HandPanel.Enabled = true;

            UpdateDisplay();
            CheckBattleEnd();
        }

        // =========================================================
        // 4. あっち向いてホイボタンが押されたときの処理
        // =========================================================
        private void ArrowUp_Click(object sender, EventArgs e)
        {
            ExecuteHoi(AcchimuitehoiLogic.Direction.Up);
        }

        private void ArrowDown_Click(object sender, EventArgs e)
        {
            ExecuteHoi(AcchimuitehoiLogic.Direction.Down);
        }

        private void ArrowLeft_Click(object sender, EventArgs e)
        {
            ExecuteHoi(AcchimuitehoiLogic.Direction.Left);
        }

        private void ArrowRight_Click(object sender, EventArgs e)
        {
            ExecuteHoi(AcchimuitehoiLogic.Direction.Right);
        }

        private async void ExecuteHoi(AcchimuitehoiLogic.Direction playerDirection)
        {
            lblMessage.Text = "ホイ！";
            PanelPointing.Enabled = false;
            await System.Threading.Tasks.Task.Delay(800);
            AcchimuitehoiLogic.Direction weakDir = (AcchimuitehoiLogic.Direction)manager.CurrentEnemy.TargetDirection;
            AcchimuitehoiLogic.Direction enemyDirection = hoiLogic.DetermineEnemyDirection(weakDir);

            if (enemyDirection == AcchimuitehoiLogic.Direction.Up)
            {
                EnemyApperance.BackgroundImage = manager.CurrentEnemy.ImageUp;
            }
            else if (enemyDirection == AcchimuitehoiLogic.Direction.Down)
            {
                EnemyApperance.BackgroundImage = manager.CurrentEnemy.ImageDown;
            }
            else if (enemyDirection == AcchimuitehoiLogic.Direction.Left)
            {
                EnemyApperance.BackgroundImage = manager.CurrentEnemy.ImageLeft;
            }
            else if (enemyDirection == AcchimuitehoiLogic.Direction.Right)
            {
                EnemyApperance.BackgroundImage = manager.CurrentEnemy.ImageRight;
            }

            bool isSuccess = hoiLogic.IsSuccess(playerDirection, enemyDirection);

            if (isSuccess)
            {
                if (manager.CurrentEnemy.HP > 1)
                {
                    lblMessage.Text = "引き当てた！ 敵に1ダメージ！\nもう一度じゃんけん…";
                }
                else 
                {
                    lblMessage.Text = "引き当てた！ 敵に1ダメージ！";
                }
            }
            else
            {
                lblMessage.Text = "残念！ はずれた！\nじゃんけん…";
            }
            await System.Threading.Tasks.Task.Delay(1500);

            manager.OnAcchimuiteHoiResult(isSuccess);
            PanelPointing.Enabled = true;

            UpdateDisplay();
            CheckBattleEnd();
        }

        // =========================================================
        // =========================================================
        // 5. 画面表示の更新（画像のHPと、パネルの切り替え）
        // =========================================================
        private void UpdateDisplay()
        {
            // --- プレイヤーのHP画像の表示制御 ---
            PlayerHP1.Visible = (manager.PlayerHP >= 1);
            PlayerHP2.Visible = (manager.PlayerHP >= 2);
            PlayerHP3.Visible = (manager.PlayerHP >= 3);

            // --- 敵のHPパネル・画像の表示制御 ---
            if (manager.CurrentEnemy != null)
            {
                if (manager.CurrentEnemy.Name == "スライム")
                {
                    SlimeHpPanel.Visible = true;
                    GolemHpPanel.Visible = false;
                    DemonHpPanel.Visible = false;
                    SlimeHP.Visible = (manager.CurrentEnemy.HP >= 1);
                }
                else if (manager.CurrentEnemy.Name == "ゴーレム")
                {
                    SlimeHpPanel.Visible = false;
                    GolemHpPanel.Visible = true;
                    DemonHpPanel.Visible = false;
                    GolemHP1.Visible = (manager.CurrentEnemy.HP >= 1);
                    GolemHP2.Visible = (manager.CurrentEnemy.HP >= 2);
                }
                else if (manager.CurrentEnemy.Name == "魔王")
                {
                    SlimeHpPanel.Visible = false;
                    GolemHpPanel.Visible = false;
                    DemonHpPanel.Visible = true;

                    DemonHP1.Visible = (manager.CurrentEnemy.HP >= 1);
                    DemonHP2.Visible = (manager.CurrentEnemy.HP >= 2);
                    DemonHP3.Visible = (manager.CurrentEnemy.HP >= 3);
                    this.BackgroundImage = Properties.Resources.魔王背景;
                }
            }


            // --- ★ここを修正：パネルと敵の手の表示切り替え ---
            if (manager.CurrentPhase == "あっち向いてホイ")
            {
                // 【あっち向いてホイフェーズ】のときだけ、方向パネルを出す！
                HandPanel.Visible = false;     // じゃんけんパネルを隠す
                PanelPointing.Visible = true;  // 方向パネルを出す
                EnemyHand.Visible = true;     // 敵の手を隠す
            }
            else
            {
                // 【じゃんけんフェーズ】や、最初の【エンカウント時（バトル）】など、
                // あっち向いてホイ以外のときは「絶対に」こちらを通るようにします
                HandPanel.Visible = true;      // じゃんけんパネルを出す
                PanelPointing.Visible = false; // ★方向パネルを絶対に隠す！
                EnemyHand.Visible = true;      // 敵の手を出す

                if (manager.CurrentEnemy != null)
                {
                    EnemyApperance.BackgroundImage = manager.CurrentEnemy.ImageFront;
                }
            }
        }

        // =========================================================
        private async void CheckBattleEnd()
        {
            if (manager.PlayerHP <= 0)
            {

                HandPanel.Enabled = false;
                PanelPointing.Enabled = false;

                UpdateDisplay();

            }
            // 敵を倒したときの処理（CheckBattleEndの中）
            else if (manager.CurrentEnemy != null && manager.CurrentEnemy.HP <= 0)
            {
                lblMessage.Text = manager.CurrentEnemy.Name + " を倒した！";
                await System.Threading.Tasks.Task.Delay(1500);

                // ★ここでStageManagerに「次行くぞ！」と指示を出すだけで...
                currentStageManager.SetupNextStage();

                // もう CurrentEnemy には自動的に「ゴーレム」や「魔王」がセットされている！
                manager.SetupEnemy(currentStageManager.CurrentEnemy);
                UpdateDisplay();

            }
        }
        // =========================================================
        // 7. 元々あった、消すとエラーになるイベントたち
        // =========================================================
        private void PanelArrow_Paint(object sender, PaintEventArgs e) { }
        private void GolemHp_Paint(object sender, PaintEventArgs e) { }
        private void EnemyHand_Click(object sender, EventArgs e) { }

        private void DemonHP1_Click(object sender, EventArgs e)
        {

        }

        private void SlimeHpPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SlimeHP_Click(object sender, EventArgs e)
        {

        }

        private void DemonHpPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GolemHP1_Click(object sender, EventArgs e)
        {

        }

        private void EnemyApperance_Click(object sender, EventArgs e)
        {

        }
    }
}