namespace Quản_lý_bán_sách
{
    partial class rpNV
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
            this.reportNV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportNV
            // 
            this.reportNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportNV.Location = new System.Drawing.Point(0, 0);
            this.reportNV.Name = "reportNV";
            this.reportNV.ServerReport.BearerToken = null;
            this.reportNV.Size = new System.Drawing.Size(800, 450);
            this.reportNV.TabIndex = 0;
            // 
            // rpNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportNV);
            this.Name = "rpNV";
            this.Text = "DanhSachNhanVien";
            this.Load += new System.EventHandler(this.DanhSachNhanVien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportNV;
    }
}