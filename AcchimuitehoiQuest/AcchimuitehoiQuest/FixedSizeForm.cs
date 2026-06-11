using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public class FixedSizeForm : Form
    {
        private Size? _fixedClientSize;

        public FixedSizeForm()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_fixedClientSize.HasValue && _fixedClientSize.Value != Size.Empty)
            {
                ApplyFixedSize(_fixedClientSize.Value);
            }
        }

        /// <summary>
        /// フォームのクライアント領域サイズを固定します。InitializeComponent() の後に呼んでください。
        /// </summary>
        /// <param name="size">固定するクライアントサイズ（ピクセル）</param>
        public void SetFixedClientSize(Size size)
        {
            _fixedClientSize = size;
            if (this.IsHandleCreated)
            {
                ApplyFixedSize(size);
            }
        }

        private void ApplyFixedSize(Size clientSize)
        {
            // クライアントサイズを設定（Designer の ClientSize を上書き）
            this.ClientSize = clientSize;

            // 非リサイズにする
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 外形サイズ（非クライアント含む）で最小/最大をロック
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            // 固定サイズ適用後に初期表示位置を再計算して中央表示を維持する
            // Designer で設定した StartPosition に応じて再センタリング
            try
            {
                if (this.StartPosition == FormStartPosition.CenterScreen)
                {
                    this.CenterToScreen();
                }
                else if (this.StartPosition == FormStartPosition.CenterParent)
                {
                    // Owner が設定されていれば親の中央へ。設定されていなくても CenterToScreen を試す。
                    if (this.Owner != null)
                        this.CenterToParent();
                    else
                        this.CenterToScreen();
                }
            }
            catch
            {
                // 安全性のため例外は無視（稀なケースのみ）
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FixedSizeForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "FixedSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}