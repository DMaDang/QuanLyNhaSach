using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_sách
{
    public partial class fDoiMatKhau : Form
    {
        public fDoiMatKhau()
        {
            InitializeComponent();
        }
        public bool checkForm(String account)
        {
            return Regex.IsMatch(account, "^[a-zA-Z0-9]{4,24}$");
        }
  
        // Kết nối Database1.mdf
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database1.mdf"";Integrated Security=True");

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select count (*) from QuanLyTaiKhoan where TenDangNhap = '" + txtTenDangNhap.Text + "'and MatKhau = '" + txtPass.Text + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            String user = txtTenDangNhap.Text.Trim();
            String password = txtPass.Text.Trim();
            String newPass = txtNewPass.Text.Trim();
            String reNewPass = txtReNewPass.Text.Trim();

            if (dataTable.Rows[0][0].ToString() == "1")
            {
                if (newPass == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới");
                    return;
                }
                if (reNewPass != newPass)
                {
                    MessageBox.Show("Vui lòng nhập lại chính xác mật khẩu!");
                }
                if (newPass == reNewPass)
                {
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter("update QuanLyTaiKhoan set MatKhau = '" + txtNewPass.Text + "'Where TenDangNhap = '" + txtTenDangNhap.Text + "'and MatKhau = '" + txtPass.Text + "'", connection);
                    DataTable dataTable2 = new DataTable();
                    dataAdapter2.Fill(dataTable2);
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();

                }
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from QuanLyTaiKhoan where TenDangNhap = '" + txtTenDangNhap.Text + "'and MatKhau = '" + txtPass.Text + "'", connection);
                SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                data.Fill(dataSet);
                int i = dataSet.Tables[0].Rows.Count;
                if (i > 0)
                {
                    if (user == "")
                    {
                        MessageBox.Show("Vui lòng nhập tài khoản!");
                        return;
                    }
                    else if (password == "")
                    {
                        MessageBox.Show("Bạn chưa điền mật khẩu cũ!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại hoặc mật khẩu cũ sai"); 
                }
                /* if (user == "")
                 {
                     MessageBox.Show("Vui lòng nhập tài khoản!");
                     return;
                 }
                 else if (password == "")        
                 {
                     MessageBox.Show("Bạn chưa điền mật khẩu cũ!");
                     return;
                 }*/

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
