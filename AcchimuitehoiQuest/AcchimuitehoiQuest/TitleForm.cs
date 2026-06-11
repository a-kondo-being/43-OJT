using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class TitleForm : FixedSizeForm
    {
        private WMPLib.WindowsMediaPlayer bgmPlayer = new WMPLib.WindowsMediaPlayer();
        public TitleForm()
        {
            InitializeComponent();
            this.Load += TitleForm_Load;
            // 任意のクライアントサイズで固定（Designer の ClientSize を上書き）
            SetFixedClientSize(new Size(1374, 769));
            // Enable transparent backcolor support
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            // Reduce flicker by enabling double buffering and optimized painting
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            // Ensure controls that use protected DoubleBuffered are set where possible
            try { typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, true, null); } catch { }
            button2.BackColor = Color.Transparent;
        }
        private void TitleForm_Load(object sender, EventArgs e)
        {
            // 2. mp3ファイルのパスを指定
            bgmPlayer.URL = "タイトルBGM.mp3";

            // （オプション）ループ再生させたい場合は以下の行を追加
            bgmPlayer.settings.setMode("loop", true);

            // 3. 再生スタート
            bgmPlayer.controls.play();
        }

        private void button2_Click(object sender, EventArgs e)

        {
            QuestForm questform = new QuestForm();
            questform.Show(this);
            // ゲーム開始の初期化処理を呼ぶ
            questform.StartNewGame();
            this.Hide();
            bgmPlayer.controls.stop();

        }
    }
}


