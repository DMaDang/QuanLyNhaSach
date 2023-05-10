namespace Quản_lý_bán_sách
{
    partial class ViewReportNV
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
            this.btnViewReportNV = new System.Windows.Forms.Button();
            this.crvReportNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvReportHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btnViewReportNV
            // 
            this.btnViewReportNV.Location = new System.Drawing.Point(63, 27);
            this.btnViewReportNV.Name = "btnViewReportNV";
            this.btnViewReportNV.Size = new System.Drawing.Size(154, 53);
            this.btnViewReportNV.TabIndex = 0;
            this.btnViewReportNV.Text = "Xem Report";
            this.btnViewReportNV.UseVisualStyleBackColor = true;
            this.btnViewReportNV.Click += new System.EventHandler(this.btnViewReportNV_Click);
            // 
            // crvReportNV
            // 
            this.crvReportNV.ActiveViewIndex = -1;
            this.crvReportNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportNV.Location = new System.Drawing.Point(4, 86);
            this.crvReportNV.Name = "crvReportNV";
            this.crvReportNV.Size = new System.Drawing.Size(1925, 920);
            this.crvReportNV.TabIndex = 1;
            // 
            // crvReportHD
            // 
            this.crvReportHD.ActiveViewIndex = -1;
            this.crvReportHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportHD.Location = new System.Drawing.Point(12, 98);
            this.crvReportHD.Name = "crvReportHD";
            this.crvReportHD.Size = new System.Drawing.Size(1890, 920);
            this.crvReportHD.TabIndex = 1;
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReport.Location = new System.Drawing.Point(12, 98);
            this.crvReport.Name = "crvReport";
            this.crvReport.Size = new System.Drawing.Size(1890, 920);
            this.crvReport.TabIndex = 1;
            // 
            // cr
            // 
            this.cr.ActiveViewIndex = -1;
            this.cr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cr.Cursor = System.Windows.Forms.Cursors.Default;
            this.cr.Location = new System.Drawing.Point(4, 86);
            this.cr.Name = "cr";
            this.cr.Size = new System.Drawing.Size(1925, 920);
            this.cr.TabIndex = 1;
            // 
            // ViewReportNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1030);
            this.Controls.Add(this.crvReportNV);
            this.Controls.Add(this.btnViewReportNV);
            this.Name = "ViewReportNV";
            this.Text = "ViewReportNV";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewReportNV;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportNV;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportHD;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cr;
    }
}