namespace Quản_lý_bán_sách
{
    partial class rpHD
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
            this.reportHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportHD
            // 
            this.reportHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportHD.LocalReport.ReportEmbeddedResource = "Quản_lý_bán_sách.Report1.rdlc";
            this.reportHD.Location = new System.Drawing.Point(0, 0);
            this.reportHD.Name = "reportHD";
            this.reportHD.ServerReport.BearerToken = null;
            this.reportHD.Size = new System.Drawing.Size(800, 450);
            this.reportHD.TabIndex = 0;
            // 
            // rpHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportHD);
            this.Name = "rpHD";
            this.Text = "InHoaDon";
            this.Load += new System.EventHandler(this.rpHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportHD;
    }
}