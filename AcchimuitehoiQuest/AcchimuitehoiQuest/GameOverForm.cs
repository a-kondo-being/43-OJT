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
        public GameOverForm()
        {
            InitializeComponent();
            // 任意のクライアントサイズで固定（Designer の ClientSize を上書き）
            SetFixedClientSize(new Size(1374, 769));
        }
        private void buttonBacktoTitle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
