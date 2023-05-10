namespace Quản_lý_bán_sách
{
    partial class ViewReportKho
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
            this.btnViewReportKho = new System.Windows.Forms.Button();
            this.crvKho = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btnViewReportKho
            // 
            this.btnViewReportKho.Location = new System.Drawing.Point(46, 35);
            this.btnViewReportKho.Name = "btnViewReportKho";
            this.btnViewReportKho.Size = new System.Drawing.Size(119, 60);
            this.btnViewReportKho.TabIndex = 0;
            this.btnViewReportKho.Text = "Xem Report";
            this.btnViewReportKho.UseVisualStyleBackColor = true;
            this.btnViewReportKho.Click += new System.EventHandler(this.btnViewReportKho_Click);
            // 
            // crvKho
            // 
            this.crvKho.ActiveViewIndex = -1;
            this.crvKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvKho.Location = new System.Drawing.Point(3, 130);
            this.crvKho.Name = "crvKho";
            this.crvKho.Size = new System.Drawing.Size(1909, 865);
            this.crvKho.TabIndex = 1;
            // 
            // ViewReportKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1007);
            this.Controls.Add(this.crvKho);
            this.Controls.Add(this.btnViewReportKho);
            this.Name = "ViewReportKho";
            this.Text = "ViewReportKho";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewReportKho;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvKho;
    }
}