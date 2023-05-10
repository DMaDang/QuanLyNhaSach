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
    public partial class fAdmin : Form
    {
        String connectSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database2.mdf"";Integrated Security=True";
        String connectSTR2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database1.mdf"";Integrated Security=True";
        public fAdmin()
        {
            InitializeComponent();
            LoadNhanVien1();
            LoadTaiKhoan();
            LoadHoaDon();
        }
        NhanVien nhanVien;
        DanhSachTaiKhoan danhSach;
        ModifyDanhSachQuanLy modify = new ModifyDanhSachQuanLy();
        Modify modify2 = new Modify();


        void LoadTaiKhoan()
        {
            SqlConnection connection = new SqlConnection(connectSTR2);
            String query = "Select tenDangNhap as [Tên Đăng nhập], matKhau as [Mật khẩu], email as [Email] from QuanLyTaiKhoan";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvTaiKhoan.DataSource = data;
        }
        void LoadNhanVien1()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maNhanVien as [Mã nhân viên], userName as [UserName], tenNhanVien as [Tên nhân viên], congViec as [Công việc], diaChi as [Địa chỉ], gioiTinh as [Giới tính], ngaysinh as [Ngày sinh], email as [Email], luong as [Lương] from NhanVien";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvNhanVien2.DataSource = data;

            string ak1 = "";
            if (data.Rows.Count <= 0)
            {
                ak1 = "NV001";
            }
            else
            {
                int k1;
                ak1 = "NV";
                k1 = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(2, 3));
                k1 = k1 + 1;
                if (k1 < 10)
                {
                    ak1 = ak1 + "00";
                }
                else if (k1 < 100)
                {
                    ak1 = ak1 + "0";
                }
                ak1 = ak1 + k1.ToString();
            }
            txtMaNV1.Text = ak1.ToString();
        }
        void LoadHoaDon()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maHoaDon as [Mã hóa đơn], tenSach as [Tên sách], soLuong as [Số lượng], giaTien as [Giá tiền], ngayLap as [Ngày lập], giamGia as [Giảm giá] from HoaDon";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvHoaDon.DataSource = data;
            double tongTienDT = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double soluong = Convert.ToDouble(data.Rows[i]["Số lượng"]);
                double giaTien = Convert.ToDouble(data.Rows[i]["Giá tiền"]);
                double giamGia = Convert.ToDouble(data.Rows[i]["Giảm giá"]);
                tongTienDT += soluong * giaTien * ((100 - giamGia) / 100);
            }

            txtDoanhThu.Text = tongTienDT.ToString();

            double sum = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double soluong = Convert.ToDouble(data.Rows[i]["Số lượng"]);
                if (soluong > 0)
                {
                    sum += soluong;
                }
            }
            txtSoLuong.Text = sum.ToString();
        }
        private void DeleteTxtNV1()
        {
            txtMaNV1.Text = "";
            txtUserName1.Text = "";
            txtTenNV1.Text = "";
            txtCongViec1.Text = "";
            txtDiaChi1.Text = "";
            txtGioiTinh1.Text = "";
            txtNgSinh1.Text = "";
            txtEmailNV1.Text = "";
            txtLuong1.Text = "";

        }
        private bool CheckTxtNV1()
        {
            if (txtMaNV1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên");
                return false;
            }
            if (txtUserName1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập username");
                return false;
            }
            if (txtTenNV1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
                return false;
            }
            if (txtCongViec1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập công việc");
                return false;
            }
            if (txtDiaChi1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ");
                return false;
            }
            if (txtGioiTinh1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính nhân viên");
                return false;
            }
            if (txtNgSinh1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh nhân viên");
                return false;
            }
            if (txtEmailNV1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email nhân viên");
                return false;
            }
            if (txtLuong1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập lương nhân viên");
                return false;
            }
            return true;
        }
        private void GetValuesTxtNV1()
        {
            string maNV = txtMaNV1.Text;
            string userName = txtUserName1.Text;
            string tenNV = txtTenNV1.Text;
            string congViec = txtCongViec1.Text;
            string diaChi = txtDiaChi1.Text;
            string gioiTinh = txtGioiTinh1.Text;
            string ngSinh = txtNgSinh1.Text;
            string emailNV = txtEmailNV1.Text;
            string luong = txtLuong1.Text;
            nhanVien = new NhanVien(maNV, userName, tenNV, congViec, diaChi, gioiTinh, ngSinh, emailNV, luong);
        }


        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (CheckTxtNV1())
            {
                GetValuesTxtNV1();
                string query = "insert into NhanVien values('" + nhanVien.MaNhanVien + "','" + nhanVien.UserName + "',N'" + nhanVien.TenNhanVien + "',N'" + nhanVien.CongViec + "',N'" + nhanVien.DiaChi + "', N'" + nhanVien.GioiTinh + "','" + nhanVien.NgaySinh + "','" + nhanVien.Email + "', N'" + nhanVien.Luong + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm nhân viên thành công!");
                    DeleteTxtNV1();
                    txtMaNV1.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (dtgvNhanVien2.Rows.Count > 1)
            {

                if (CheckTxtNV1())
                {
                    GetValuesTxtNV1();
                    string query = "update NhanVien set maNhanVien  = '" + nhanVien.MaNhanVien + "',userName= N'" + nhanVien.UserName + "',tenNhanVien= N'" + nhanVien.TenNhanVien + "',congViec= N'" + nhanVien.CongViec + "',diaChi= N'" + nhanVien.DiaChi + "',gioiTinh= N'" + nhanVien.GioiTinh + "',ngaySinh= '" + nhanVien.NgaySinh + "',email= '" + nhanVien.Email + "',luong= '" + nhanVien.Luong + "'";
                    query += " where maNhanVien = '" + nhanVien.MaNhanVien + "'";
                    try
                    {
                        modify.Command(query);
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                        DeleteTxtNV1();
                        txtMaNV1.ReadOnly = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                    }
                }
            }
        }
        private void txtMaNV1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV1.Text))
            {
                btnXoaNV.Enabled = false;
            }
            else
            {
                btnXoaNV.Enabled = true;
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (dtgvNhanVien2.Rows.Count > 1)
            {
                string delete = dtgvNhanVien2.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete NhanVien";
                query += " where maNhanVien = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin nhân viên thành công!");
                    DeleteTxtNV1();
                    txtMaNV1.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }


        private void txtSearchNV1_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSearchNV1.Text.Trim();
            if (timKiem == "")
            {
                LoadNhanVien1();
            }
            else
            {
                String query = "select * from NhanVien where maNhanVien like '%" + timKiem + "%'";
                dtgvNhanVien2.DataSource = modify.Table(query);
            }
        }

        private void txtNgSinh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_+-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());
        }

        private void txtLuong1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void picboxGioiTinh1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Giới tính là nam/nữ", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
        private void picboxNgaySinh1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn phải nhập ngày sinh theo định dạng năm/tháng/ngày", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void btnDSNV1_Click(object sender, EventArgs e)
        {
            ViewReportNV formReport = new ViewReportNV();
            formReport.ShowDialog();
        }

        private void btnReloadAdmin_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Refresh();
            this.Hide();
            fAdmin f = new fAdmin();
            f.ShowDialog();
          
        }

        private void dtgvNhanVien2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV1.Text = dtgvNhanVien2.SelectedRows[0].Cells[0].Value.ToString();
            txtMaNV1.ReadOnly = true;
            txtUserName1.Text = dtgvNhanVien2.SelectedRows[0].Cells[1].Value.ToString();
            txtTenNV1.Text = dtgvNhanVien2.SelectedRows[0].Cells[2].Value.ToString();
            txtCongViec1.Text = dtgvNhanVien2.SelectedRows[0].Cells[3].Value.ToString();
            txtDiaChi1.Text = dtgvNhanVien2.SelectedRows[0].Cells[4].Value.ToString();
            txtGioiTinh1.Text = dtgvNhanVien2.SelectedRows[0].Cells[5].Value.ToString();
            txtEmailNV1.Text = dtgvNhanVien2.SelectedRows[0].Cells[7].Value.ToString();
            txtLuong1.Text = dtgvNhanVien2.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void btnAdminDK_Click(object sender, EventArgs e)
        {
            fDangKy f = new fDangKy();
            f.ShowDialog();
        }

        private void btnAdminDMK_Click(object sender, EventArgs e)
        {
            fDoiMatKhau f = new fDoiMatKhau();
            f.ShowDialog();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            ViewReportHD formReport = new ViewReportHD();
            formReport.ShowDialog();
        }

    
    }
    
}
