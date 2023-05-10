namespace Quản_lý_bán_sách
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDangKy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuenMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1413, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDangNhap,
            this.tsmDangKy,
            this.tsmDoiMatKhau,
            this.tsmQuenMatKhau,
            this.tsmThoat});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // tsmDangNhap
            // 
            this.tsmDangNhap.Name = "tsmDangNhap";
            this.tsmDangNhap.Size = new System.Drawing.Size(236, 34);
            this.tsmDangNhap.Text = "Đăng nhập";
            this.tsmDangNhap.Click += new System.EventHandler(this.tsmDangNhap_Click);
            // 
            // tsmDangKy
            // 
            this.tsmDangKy.Name = "tsmDangKy";
            this.tsmDangKy.Size = new System.Drawing.Size(236, 34);
            this.tsmDangKy.Text = "Đăng ký";
            this.tsmDangKy.Click += new System.EventHandler(this.tsmDangKy_Click);
            // 
            // tsmDoiMatKhau
            // 
            this.tsmDoiMatKhau.Name = "tsmDoiMatKhau";
            this.tsmDoiMatKhau.Size = new System.Drawing.Size(236, 34);
            this.tsmDoiMatKhau.Text = "Đổi mật khẩu";
            this.tsmDoiMatKhau.Click += new System.EventHandler(this.tsmDoiMatKhau_Click);
            // 
            // tsmQuenMatKhau
            // 
            this.tsmQuenMatKhau.Name = "tsmQuenMatKhau";
            this.tsmQuenMatKhau.Size = new System.Drawing.Size(236, 34);
            this.tsmQuenMatKhau.Text = "Quên mật khẩu";
            this.tsmQuenMatKhau.Click += new System.EventHandler(this.tsmQuenMatKhau_Click);
            // 
            // tsmThoat
            // 
            this.tsmThoat.Name = "tsmThoat";
            this.tsmThoat.Size = new System.Drawing.Size(236, 34);
            this.tsmThoat.Text = "Thoát";
            this.tsmThoat.Click += new System.EventHandler(this.tsmThoat_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Quản_lý_bán_sách.Properties.Resources.manhinhchinh1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1413, 529);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán sách";
            this.Activated += new System.EventHandler(this.fMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDangNhap;
        private System.Windows.Forms.ToolStripMenuItem tsmThoat;
        private System.Windows.Forms.ToolStripMenuItem tsmDangKy;
        private System.Windows.Forms.ToolStripMenuItem tsmDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem tsmQuenMatKhau;
        private System.Windows.Forms.Timer timer1;
    }
}

