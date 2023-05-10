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
using Microsoft.ReportingServices.Interfaces;

namespace Quản_lý_bán_sách
{
    public partial class rpHD : Form
    {
        ModifyDanhSachQuanLy modify = new ModifyDanhSachQuanLy();

        public rpHD()
        {
            InitializeComponent();
        }

        private void rpHD_Load(object sender, EventArgs e)
        {

            reportHD.LocalReport.ReportPath = "../CNPM/Quản lý bán sách/Quản lý bán sách/Report1.rdlc";
            /*            reportHD.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "../../Report1.rdlc";
            */
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = modify.Table("Select * from HoaDon");
            reportHD.LocalReport.DataSources.Add(reportDataSource);
            this.reportHD.RefreshReport();
        }
    }
}
