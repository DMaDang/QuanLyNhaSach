using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_sách
{
    public partial class ViewReportKho : Form
    {
        String connectSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database2.mdf"";Integrated Security=True";
        public ViewReportKho()
        {
            InitializeComponent();
        }

        private void btnViewReportKho_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maSach, tenSach, soLuong, tgNhapKho as [thoiGianNhapKHo], tgXuatKho as [thoiGianXuatKho] from Kho";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            rpKS rpt = new rpKS();
            rpt.SetDataSource(data);
            crvKho.ReportSource = rpt;
            rpt.Refresh();
        }
    }
}
