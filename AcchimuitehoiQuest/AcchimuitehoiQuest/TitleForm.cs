using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            button2.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)

        {
            //QusetForm questform = new QuestForm();

            //questform.Show();

            this.Hide();

        }

        private void TitleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
