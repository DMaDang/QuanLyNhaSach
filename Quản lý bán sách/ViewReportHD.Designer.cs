namespace Quản_lý_bán_sách
{
    partial class ViewReportHD
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
            this.btnViewReport = new System.Windows.Forms.Button();
            this.crvReportHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(48, 23);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(141, 54);
            this.btnViewReport.TabIndex = 0;
            this.btnViewReport.Text = "Xem Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // crvReportHD
            // 
            this.crvReportHD.ActiveViewIndex = -1;
            this.crvReportHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportHD.Location = new System.Drawing.Point(2, 94);
            this.crvReportHD.Name = "crvReportHD";
            this.crvReportHD.Size = new System.Drawing.Size(1927, 954);
            this.crvReportHD.TabIndex = 1;
            // 
            // ViewReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.crvReportHD);
            this.Controls.Add(this.btnViewReport);
            this.Name = "ViewReportHD";
            this.Text = "Report hóa đơn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportHD;
    }
}