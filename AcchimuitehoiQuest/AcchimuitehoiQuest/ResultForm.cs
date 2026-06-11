using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class ResultForm : FixedSizeForm
    {
        public ResultForm()
        {
            InitializeComponent();
            // 任意のクライアントサイズで固定（Designer の ClientSize を上書き）
            SetFixedClientSize(new Size(1374, 769));
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            button1.BackColor = Color.Transparent;
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
            // ダイアログを閉じるだけにして、呼び出し元（QuestForm）がタイトル表示を制御する
            this.Close();
        }
    }
}
