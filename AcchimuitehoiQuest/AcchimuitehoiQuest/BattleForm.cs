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
        StageManager stageManager = null;

        // デフォルトコンストラクタ（Designer が使う）
        public BattleForm()
        {
            InitializeComponent();
            // Reduce flicker: enable double buffering and optimized painting
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint, true);
            this.UpdateStyles();
            try { typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, true, null); } catch { }
            // Try to enable double buffering on heavy child controls
            try { if (HandPanel != null) HandPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(HandPanel, true, null); } catch { }
            try { if (PanelPointing != null) PanelPointing.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(PanelPointing, true, null); } catch { }
            try { if (EnemyApperance != null) EnemyApperance.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(EnemyApperance, true, null); } catch { }
            try { if (EnemyHand != null) EnemyHand.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(EnemyHand, true, null); } catch { }
        }

        // 依存注入用のコンストラクタ
        public BattleForm(BattleManager manager, StageManager stageManager)
            : this()
        {
            this.manager = manager ?? throw new ArgumentNullException(nameof(manager));
            this.stageManager = stageManager; // null でも受け入れる
        }
        bool isAiko = false;

        // StageManager の参照（QuestForm から渡されることを想定）
        // 注意: stageManager は null でも受け入れます（後で manager.CurrentEnemy を使う）

        // =========================================================
        // 2. 画面が開いた瞬間（エンカウント時）の初期化処理
        // =========================================================
        private async void BattleForm_Load(object sender, EventArgs e)
        {
            // manager に敵がセットされていなければ、stageManager から受け取る
            if (manager.CurrentEnemy == null && stageManager != null && stageManager.CurrentEnemy != null)
            {
                manager.SetupEnemy(stageManager.CurrentEnemy);
            }
            if (manager.CurrentEnemy != null && manager.CurrentEnemy.Name == "魔王")
            {
                this.BackgroundImage = Properties.Resources.魔王背景;
            }
            if (manager.CurrentEnemy != null)
            {
                lblMessage.Text = manager.CurrentEnemy.Name + "が現れた！";
            }

            // 初期表示ではパネル類は一旦隠して、UpdateDisplay によって正しく表示させる
            HandPanel.Visible = false;
            PanelPointing.Visible = false;
            EnemyHand.Visible = false;

            PlayerHP1.Visible = (manager.PlayerHP >= 1);
            PlayerHP2.Visible = (manager.PlayerHP >= 2);
            PlayerHP3.Visible = (manager.PlayerHP >= 3);

            // すべての敵HPパネルを隠しておく（UpdateDisplay で正しく切り替える）
            SlimeHpPanel.Visible = false;
            GolemHpPanel.Visible = false;
            DemonHpPanel.Visible = false;

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
            // Batch layout updates to reduce flicker
            this.SuspendLayout();
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


            // --- パネルと敵の手の表示切り替え ---
            bool isHoi = (manager.CurrentPhase == "あっち向いてホイ");
            HandPanel.Visible = !isHoi;
            PanelPointing.Visible = isHoi;
            EnemyHand.Visible = true; // 常に表示（画像差し替えで変化する）

            if (manager.CurrentEnemy != null)
            {
                // Only update appearance image when necessary to avoid re-rendering
                if (EnemyApperance.BackgroundImage != manager.CurrentEnemy.ImageFront)
                {
                    EnemyApperance.BackgroundImage = manager.CurrentEnemy.ImageFront;
                }
            }

            // --- ボタンの有効/無効をフェーズに合わせて切り替え ---
            bool isJanken = (manager.CurrentPhase == "じゃんけん");
            PlayerHandGu.Enabled = isJanken;
            PlayerHandChoki.Enabled = isJanken;
            PlayerHandPa.Enabled = isJanken;

            PanelPointing.Enabled = !isJanken;
            ArrowUp.Enabled = !isJanken;
            ArrowDown.Enabled = !isJanken;
            ArrowLeft.Enabled = !isJanken;
            ArrowRight.Enabled = !isJanken;

            this.ResumeLayout();
        }

        // =========================================================
        private async void CheckBattleEnd()
        {
            if (manager.PlayerHP <= 0)
            {
                HandPanel.Enabled = false;
                PanelPointing.Enabled = false;
                UpdateDisplay();

                // プレイヤーがやられたらこのバトル画面を閉じて呼び出し元へ戻す
                await System.Threading.Tasks.Task.Delay(800);
                this.Close();
                return;
            }
            // 敵を倒したときの処理（CheckBattleEndの中）
            else if (manager.CurrentEnemy != null && manager.CurrentEnemy.HP <= 0)
            {
                HandPanel.Enabled = false;
                PanelPointing.Enabled = false;
                lblMessage.Text = manager.CurrentEnemy.Name + " を倒した！";
                await System.Threading.Tasks.Task.Delay(1500);

                // 敵を倒したら、このバトル画面は閉じて QuestForm に処理を戻す
                await System.Threading.Tasks.Task.Delay(800);
                this.Close();
                return;
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
