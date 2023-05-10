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
    public partial class fChiTietHoaDon : Form
    {
        String connectSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database2.mdf"";Integrated Security=True";
        public fChiTietHoaDon()
        {
            InitializeComponent();
            LoadChiTietHoaDon();
        }
        void LoadChiTietHoaDon()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select HoaDon.maHoaDon as [Mã Hóa đơn], Sach.maSach as [Mã sách], HoaDon.soLuong as [Số lượng], HoaDon.soLuong*HoaDon.giaTien*(100-HoaDon.giamGia)/100 as [Thành tiền] from HoaDon,Sach where HoaDon.tenSach = Sach.tenSach";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvCTHD.DataSource = data;
            double tongTien = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double thanhTien = Convert.ToDouble(data.Rows[i]["Thành tiền"]);
                tongTien += thanhTien;
            }
            txtTongTienCTHD.Text = tongTien.ToString();
        }
    }
}
