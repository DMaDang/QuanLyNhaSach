using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_sách
{
    public partial class rpNV : Form
    {
        public rpNV()
        {
            InitializeComponent();
        }
        ModifyDanhSachQuanLy modify = new ModifyDanhSachQuanLy();

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            reportNV.LocalReport.ReportPath = "../../Report4.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = modify.Table("Select * from NhanVien");
            reportNV.LocalReport.DataSources.Add(reportDataSource);
            this.reportNV.RefreshReport();
        }
     
    }
}
