using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_sách
{
    public partial class rpPhieuNhap : Form
    {
        public rpPhieuNhap()
        {
            InitializeComponent();
        }
        ModifyDanhSachQuanLy modify = new ModifyDanhSachQuanLy();
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            reportPN.LocalReport.ReportPath = "../../Report3.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet3";
            reportDataSource.Value = modify.Table("Select * from Kho");
            reportPN.LocalReport.DataSources.Add(reportDataSource);
            this.reportPN.RefreshReport();
        }
    }
}
