using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class ResultForm : FixedSizeForm
    {
        private WMPLib.WindowsMediaPlayer bgmPlayer = new WMPLib.WindowsMediaPlayer();
        public ResultForm()
        {
             InitializeComponent();
            this.Load += ResultForm_Load;
            // 任意のクライアントサイズで固定（Designer の ClientSize を上書き）
            SetFixedClientSize(new Size(1374, 769));
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            button1.BackColor = Color.Transparent;
        }
        private void ResultForm_Load(object sender, EventArgs e)
        {
            // 2. mp3ファイルのパスを指定して再生スタート
            bgmPlayer.URL = "クリア画面BGM.mp3";
            bgmPlayer.controls.play();
        }
        public void SetStatus(string status)
        {
            try
            {
                label1.Text = status;
            }
            catch
            {
                // ignore
            }
        }
        private void buttonToTitle_Click(object sender, EventArgs e)
        {
            bgmPlayer.controls.stop();
            // ダイアログを閉じるだけにして、呼び出し元（QuestForm）がタイトル表示を制御する
            this.Close();
        }
    }
}
