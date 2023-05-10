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
    public partial class ViewReportHD : Form
    {
        String connectSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database2.mdf"";Integrated Security=True";
        public ViewReportHD()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectSTR);
           /* giaTien * ((100 - giamGia) / 100)*/
            String query = "Select maHoaDon, tenSach, soLuong, giaTien as thanhTien, ngayLap from HoaDon";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            rpHoaDon rpt = new rpHoaDon();
            rpt.SetDataSource(data); 
            crvReportHD.ReportSource = rpt;
            rpt.Refresh();

        }
    }
}
