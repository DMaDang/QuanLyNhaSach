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
    public partial class ViewReportNV : Form
    {
        String connectSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database2.mdf"";Integrated Security=True";
        public ViewReportNV()
        {
            InitializeComponent();
        }

        private void btnViewReportNV_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maNhanVien , userName, tenNhanVien, congViec, diaChi, gioiTinh, ngaysinh, email, luong from NhanVien";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            rpNhanVien rpt = new rpNhanVien();  
            rpt.SetDataSource(data);
            crvReportNV.ReportSource = rpt;
            rpt.Refresh();
        }
    }
}
