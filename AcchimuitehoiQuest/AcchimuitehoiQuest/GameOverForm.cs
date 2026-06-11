using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class GameOverForm : FixedSizeForm
    {
        private WMPLib.WindowsMediaPlayer bgmPlayer = new WMPLib.WindowsMediaPlayer();
        public GameOverForm()
        {
            InitializeComponent();
            this.Load += GameOverForm_Load;
            // 任意のクライアントサイズで固定（Designer の ClientSize を上書き）
            SetFixedClientSize(new Size(1374, 769));
        }
        private void GameOverForm_Load(object sender, EventArgs e)
        {
            // 2. mp3ファイルのパスを指定
            bgmPlayer.URL = "ゲームオーバーBGM.mp3";

            // ※ゲームオーバーの曲は1回だけ流すことが多いのでループ設定は入れていません。
            // もしループ再生させたい場合は、以下の行の「//」を消して有効にしてください。
            // bgmPlayer.settings.setMode("loop", true);

            // 3. 再生スタート
            bgmPlayer.controls.play();
        }
        private void buttonBacktoTitle_Click(object sender, EventArgs e)
        {
            Application.Exit();
            bgmPlayer.controls.stop();
        }
    }
}
