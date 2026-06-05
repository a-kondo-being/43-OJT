using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            button1.BackColor = Color.Transparent;
        }
        private void buttonToTitle_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
