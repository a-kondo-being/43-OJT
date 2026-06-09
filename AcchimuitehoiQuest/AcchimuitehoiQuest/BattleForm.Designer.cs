namespace AcchimuitehoiQuest
{
    partial class BattleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleForm));
            this.EnemyApperance = new System.Windows.Forms.PictureBox();
            this.HandPanel = new System.Windows.Forms.Panel();
            this.PlayerHandPa = new System.Windows.Forms.Button();
            this.PlayerHandChoki = new System.Windows.Forms.Button();
            this.PlayerHandGu = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.PlayerHP1 = new System.Windows.Forms.PictureBox();
            this.PlayerHP2 = new System.Windows.Forms.PictureBox();
            this.PlayerHP3 = new System.Windows.Forms.PictureBox();
            this.SlimeHP = new System.Windows.Forms.PictureBox();
            this.GolemHpPanel = new System.Windows.Forms.Panel();
            this.GolemHP2 = new System.Windows.Forms.PictureBox();
            this.EnemyHand = new System.Windows.Forms.PictureBox();
            this.PanelPointing = new System.Windows.Forms.Panel();
            this.ArrowRight = new System.Windows.Forms.Button();
            this.ArrowDown = new System.Windows.Forms.Button();
            this.ArrowLeft = new System.Windows.Forms.Button();
            this.ArrowUp = new System.Windows.Forms.Button();
            this.GolemHP1 = new System.Windows.Forms.PictureBox();
            this.SlimeHpPanel = new System.Windows.Forms.Panel();
            this.DemonHpPanel = new System.Windows.Forms.Panel();
            this.DemonHP3 = new System.Windows.Forms.PictureBox();
            this.DemonHP1 = new System.Windows.Forms.PictureBox();
            this.DemonHP2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyApperance)).BeginInit();
            this.HandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimeHP)).BeginInit();
            this.GolemHpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GolemHP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyHand)).BeginInit();
            this.PanelPointing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GolemHP1)).BeginInit();
            this.SlimeHpPanel.SuspendLayout();
            this.DemonHpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemonHP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemonHP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemonHP2)).BeginInit();
            this.SuspendLayout();
            // 
            // EnemyApperance
            // 
            this.EnemyApperance.BackColor = System.Drawing.Color.Transparent;
            this.EnemyApperance.BackgroundImage = global::AcchimuitehoiQuest.Properties.Resources.スライム正面_removebg_preview;
            this.EnemyApperance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EnemyApperance.Location = new System.Drawing.Point(411, 173);
            this.EnemyApperance.Name = "EnemyApperance";
            this.EnemyApperance.Size = new System.Drawing.Size(509, 295);
            this.EnemyApperance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EnemyApperance.TabIndex = 0;
            this.EnemyApperance.TabStop = false;
            this.EnemyApperance.Click += new System.EventHandler(this.EnemyApperance_Click);
            // 
            // HandPanel
            // 
            this.HandPanel.BackColor = System.Drawing.Color.Transparent;
            this.HandPanel.Controls.Add(this.PlayerHandPa);
            this.HandPanel.Controls.Add(this.PlayerHandChoki);
            this.HandPanel.Controls.Add(this.PlayerHandGu);
            this.HandPanel.Location = new System.Drawing.Point(76, 526);
            this.HandPanel.Name = "HandPanel";
            this.HandPanel.Size = new System.Drawing.Size(1141, 252);
            this.HandPanel.TabIndex = 1;
            // 
            // PlayerHandPa
            // 
            this.PlayerHandPa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerHandPa.BackgroundImage")));
            this.PlayerHandPa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerHandPa.Location = new System.Drawing.Point(865, 18);
            this.PlayerHandPa.Name = "PlayerHandPa";
            this.PlayerHandPa.Size = new System.Drawing.Size(212, 217);
            this.PlayerHandPa.TabIndex = 14;
            this.PlayerHandPa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PlayerHandPa.UseVisualStyleBackColor = true;
            this.PlayerHandPa.Click += new System.EventHandler(this.PlayerHandPa_Click);
            // 
            // PlayerHandChoki
            // 
            this.PlayerHandChoki.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerHandChoki.BackgroundImage")));
            this.PlayerHandChoki.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerHandChoki.Location = new System.Drawing.Point(461, 18);
            this.PlayerHandChoki.Name = "PlayerHandChoki";
            this.PlayerHandChoki.Size = new System.Drawing.Size(212, 217);
            this.PlayerHandChoki.TabIndex = 13;
            this.PlayerHandChoki.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PlayerHandChoki.UseVisualStyleBackColor = true;
            this.PlayerHandChoki.Click += new System.EventHandler(this.PlayerHandChoki_Click);
            // 
            // PlayerHandGu
            // 
            this.PlayerHandGu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerHandGu.BackgroundImage")));
            this.PlayerHandGu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerHandGu.Location = new System.Drawing.Point(70, 23);
            this.PlayerHandGu.Name = "PlayerHandGu";
            this.PlayerHandGu.Size = new System.Drawing.Size(212, 217);
            this.PlayerHandGu.TabIndex = 12;
            this.PlayerHandGu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PlayerHandGu.UseVisualStyleBackColor = true;
            this.PlayerHandGu.Click += new System.EventHandler(this.PlayerHandGu_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.MenuText;
            this.lblMessage.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(144, 65);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1009, 105);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "あいうえお";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerHP1
            // 
            this.PlayerHP1.BackColor = System.Drawing.Color.Transparent;
            this.PlayerHP1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerHP1.BackgroundImage")));
            this.PlayerHP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerHP1.Location = new System.Drawing.Point(0, 1);
            this.PlayerHP1.Name = "PlayerHP1";
            this.PlayerHP1.Size = new System.Drawing.Size(50, 50);
            this.PlayerHP1.TabIndex = 3;
            this.PlayerHP1.TabStop = false;
            // 
            // PlayerHP2
            // 
            this.PlayerHP2.BackColor = System.Drawing.Color.Transparent;
            this.PlayerHP2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerHP2.BackgroundImage")));
            this.PlayerHP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerHP2.Location = new System.Drawing.Point(47, 1);
            this.PlayerHP2.Name = "PlayerHP2";
            this.PlayerHP2.Size = new System.Drawing.Size(50, 50);
            this.PlayerHP2.TabIndex = 4;
            this.PlayerHP2.TabStop = false;
            // 
            // PlayerHP3
            // 
            this.PlayerHP3.BackColor = System.Drawing.Color.Transparent;
            this.PlayerHP3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerHP3.BackgroundImage")));
            this.PlayerHP3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerHP3.Location = new System.Drawing.Point(97, 1);
            this.PlayerHP3.Name = "PlayerHP3";
            this.PlayerHP3.Size = new System.Drawing.Size(50, 50);
            this.PlayerHP3.TabIndex = 5;
            this.PlayerHP3.TabStop = false;
            // 
            // SlimeHP
            // 
            this.SlimeHP.BackColor = System.Drawing.Color.Transparent;
            this.SlimeHP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SlimeHP.BackgroundImage")));
            this.SlimeHP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SlimeHP.Location = new System.Drawing.Point(0, 3);
            this.SlimeHP.Name = "SlimeHP";
            this.SlimeHP.Size = new System.Drawing.Size(50, 50);
            this.SlimeHP.TabIndex = 6;
            this.SlimeHP.TabStop = false;
            this.SlimeHP.Click += new System.EventHandler(this.SlimeHP_Click);
            // 
            // GolemHpPanel
            // 
            this.GolemHpPanel.BackColor = System.Drawing.Color.Transparent;
            this.GolemHpPanel.Controls.Add(this.GolemHP1);
            this.GolemHpPanel.Controls.Add(this.GolemHP2);
            this.GolemHpPanel.Location = new System.Drawing.Point(800, 190);
            this.GolemHpPanel.Name = "GolemHpPanel";
            this.GolemHpPanel.Size = new System.Drawing.Size(98, 53);
            this.GolemHpPanel.TabIndex = 9;
            this.GolemHpPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GolemHp_Paint);
            // 
            // GolemHP2
            // 
            this.GolemHP2.BackColor = System.Drawing.Color.Transparent;
            this.GolemHP2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GolemHP2.BackgroundImage")));
            this.GolemHP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GolemHP2.Location = new System.Drawing.Point(47, 0);
            this.GolemHP2.Name = "GolemHP2";
            this.GolemHP2.Size = new System.Drawing.Size(50, 50);
            this.GolemHP2.TabIndex = 8;
            this.GolemHP2.TabStop = false;
            // 
            // EnemyHand
            // 
            this.EnemyHand.BackColor = System.Drawing.SystemColors.Desktop;
            this.EnemyHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnemyHand.Location = new System.Drawing.Point(366, 285);
            this.EnemyHand.Name = "EnemyHand";
            this.EnemyHand.Size = new System.Drawing.Size(150, 120);
            this.EnemyHand.TabIndex = 10;
            this.EnemyHand.TabStop = false;
            this.EnemyHand.Click += new System.EventHandler(this.EnemyHand_Click);
            // 
            // PanelPointing
            // 
            this.PanelPointing.BackColor = System.Drawing.Color.Transparent;
            this.PanelPointing.Controls.Add(this.ArrowRight);
            this.PanelPointing.Controls.Add(this.ArrowDown);
            this.PanelPointing.Controls.Add(this.ArrowLeft);
            this.PanelPointing.Controls.Add(this.ArrowUp);
            this.PanelPointing.Location = new System.Drawing.Point(337, 449);
            this.PanelPointing.Name = "PanelPointing";
            this.PanelPointing.Size = new System.Drawing.Size(583, 329);
            this.PanelPointing.TabIndex = 11;
            this.PanelPointing.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelArrow_Paint);
            // 
            // ArrowRight
            // 
            this.ArrowRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ArrowRight.BackgroundImage")));
            this.ArrowRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ArrowRight.Location = new System.Drawing.Point(395, 171);
            this.ArrowRight.Name = "ArrowRight";
            this.ArrowRight.Size = new System.Drawing.Size(177, 150);
            this.ArrowRight.TabIndex = 3;
            this.ArrowRight.UseCompatibleTextRendering = true;
            this.ArrowRight.UseVisualStyleBackColor = true;
            this.ArrowRight.Click += new System.EventHandler(this.ArrowRight_Click);
            // 
            // ArrowDown
            // 
            this.ArrowDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ArrowDown.BackgroundImage")));
            this.ArrowDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ArrowDown.Location = new System.Drawing.Point(212, 171);
            this.ArrowDown.Name = "ArrowDown";
            this.ArrowDown.Size = new System.Drawing.Size(177, 150);
            this.ArrowDown.TabIndex = 2;
            this.ArrowDown.UseVisualStyleBackColor = true;
            this.ArrowDown.Click += new System.EventHandler(this.ArrowDown_Click);
            // 
            // ArrowLeft
            // 
            this.ArrowLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ArrowLeft.BackgroundImage")));
            this.ArrowLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ArrowLeft.Location = new System.Drawing.Point(29, 171);
            this.ArrowLeft.Name = "ArrowLeft";
            this.ArrowLeft.Size = new System.Drawing.Size(177, 150);
            this.ArrowLeft.TabIndex = 1;
            this.ArrowLeft.UseVisualStyleBackColor = true;
            this.ArrowLeft.Click += new System.EventHandler(this.ArrowLeft_Click);
            // 
            // ArrowUp
            // 
            this.ArrowUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ArrowUp.BackgroundImage")));
            this.ArrowUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ArrowUp.Location = new System.Drawing.Point(212, 15);
            this.ArrowUp.Name = "ArrowUp";
            this.ArrowUp.Size = new System.Drawing.Size(177, 150);
            this.ArrowUp.TabIndex = 0;
            this.ArrowUp.UseVisualStyleBackColor = true;
            this.ArrowUp.Click += new System.EventHandler(this.ArrowUp_Click);
            // 
            // GolemHP1
            // 
            this.GolemHP1.BackColor = System.Drawing.Color.Transparent;
            this.GolemHP1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GolemHP1.BackgroundImage")));
            this.GolemHP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GolemHP1.Location = new System.Drawing.Point(-2, 0);
            this.GolemHP1.Name = "GolemHP1";
            this.GolemHP1.Size = new System.Drawing.Size(50, 50);
            this.GolemHP1.TabIndex = 7;
            this.GolemHP1.TabStop = false;
            this.GolemHP1.Click += new System.EventHandler(this.GolemHP1_Click);
            // 
            // SlimeHpPanel
            // 
            this.SlimeHpPanel.BackColor = System.Drawing.Color.Transparent;
            this.SlimeHpPanel.Controls.Add(this.SlimeHP);
            this.SlimeHpPanel.Location = new System.Drawing.Point(821, 185);
            this.SlimeHpPanel.Name = "SlimeHpPanel";
            this.SlimeHpPanel.Size = new System.Drawing.Size(53, 55);
            this.SlimeHpPanel.TabIndex = 13;
            // 
            // DemonHpPanel
            // 
            this.DemonHpPanel.BackColor = System.Drawing.Color.Transparent;
            this.DemonHpPanel.Controls.Add(this.DemonHP3);
            this.DemonHpPanel.Controls.Add(this.DemonHP1);
            this.DemonHpPanel.Controls.Add(this.DemonHP2);
            this.DemonHpPanel.Location = new System.Drawing.Point(773, 186);
            this.DemonHpPanel.Name = "DemonHpPanel";
            this.DemonHpPanel.Size = new System.Drawing.Size(147, 57);
            this.DemonHpPanel.TabIndex = 14;
            // 
            // DemonHP3
            // 
            this.DemonHP3.BackColor = System.Drawing.Color.Transparent;
            this.DemonHP3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DemonHP3.BackgroundImage")));
            this.DemonHP3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DemonHP3.Location = new System.Drawing.Point(99, 3);
            this.DemonHP3.Name = "DemonHP3";
            this.DemonHP3.Size = new System.Drawing.Size(50, 50);
            this.DemonHP3.TabIndex = 15;
            this.DemonHP3.TabStop = false;
            // 
            // DemonHP1
            // 
            this.DemonHP1.BackColor = System.Drawing.Color.Transparent;
            this.DemonHP1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DemonHP1.BackgroundImage")));
            this.DemonHP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DemonHP1.Location = new System.Drawing.Point(0, 3);
            this.DemonHP1.Name = "DemonHP1";
            this.DemonHP1.Size = new System.Drawing.Size(50, 50);
            this.DemonHP1.TabIndex = 14;
            this.DemonHP1.TabStop = false;
            // 
            // DemonHP2
            // 
            this.DemonHP2.BackColor = System.Drawing.Color.Transparent;
            this.DemonHP2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DemonHP2.BackgroundImage")));
            this.DemonHP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DemonHP2.Location = new System.Drawing.Point(49, 3);
            this.DemonHP2.Name = "DemonHP2";
            this.DemonHP2.Size = new System.Drawing.Size(50, 50);
            this.DemonHP2.TabIndex = 13;
            this.DemonHP2.TabStop = false;
            // 
            // BattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1311, 778);
            this.Controls.Add(this.GolemHpPanel);
            this.Controls.Add(this.DemonHpPanel);
            this.Controls.Add(this.SlimeHpPanel);
            this.Controls.Add(this.EnemyHand);
            this.Controls.Add(this.PanelPointing);
            this.Controls.Add(this.PlayerHP3);
            this.Controls.Add(this.PlayerHP2);
            this.Controls.Add(this.PlayerHP1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.HandPanel);
            this.Controls.Add(this.EnemyApperance);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BattleForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BattleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EnemyApperance)).EndInit();
            this.HandPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimeHP)).EndInit();
            this.GolemHpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GolemHP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyHand)).EndInit();
            this.PanelPointing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GolemHP1)).EndInit();
            this.SlimeHpPanel.ResumeLayout(false);
            this.DemonHpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DemonHP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemonHP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemonHP2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox EnemyApperance;
        private System.Windows.Forms.Panel HandPanel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox PlayerHP1;
        private System.Windows.Forms.PictureBox PlayerHP2;
        private System.Windows.Forms.PictureBox PlayerHP3;
        private System.Windows.Forms.PictureBox SlimeHP;
        private System.Windows.Forms.Panel GolemHpPanel;
        private System.Windows.Forms.PictureBox GolemHP2;
        private System.Windows.Forms.PictureBox EnemyHand;
        private System.Windows.Forms.Panel PanelPointing;
        private System.Windows.Forms.Button PlayerHandGu;
        private System.Windows.Forms.Button PlayerHandPa;
        private System.Windows.Forms.Button PlayerHandChoki;
        private System.Windows.Forms.Button ArrowRight;
        private System.Windows.Forms.Button ArrowDown;
        private System.Windows.Forms.Button ArrowLeft;
        private System.Windows.Forms.Button ArrowUp;
        private System.Windows.Forms.PictureBox GolemHP1;
        private System.Windows.Forms.Panel SlimeHpPanel;
        private System.Windows.Forms.Panel DemonHpPanel;
        private System.Windows.Forms.PictureBox DemonHP3;
        private System.Windows.Forms.PictureBox DemonHP1;
        private System.Windows.Forms.PictureBox DemonHP2;
    }
}