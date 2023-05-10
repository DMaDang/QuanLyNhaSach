using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;    
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.Reporting.WinForms;
using DevComponents.DotNetBar;


namespace Quản_lý_bán_sách
{
    public partial class fDanhSachQuanLy : Form
    {
        // Kết nối Database2.mdf 
        String connectSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database2.mdf"";Integrated Security=True";

        public fDanhSachQuanLy()
        {
            InitializeComponent();
            LoadDoanhThu();
            LoadSach();
            LoadHoaDon();
            LoadKho();
           /* LoadNhanVien();*/
            LoadLoaiSach();
            LoadNhaXuatBan();
            LoadNhaCungCap();
        }
        ModifyDanhSachQuanLy modify = new ModifyDanhSachQuanLy();
        HoaDon hoaDon;
        Kho khoSach;
        Sach sach;
        NhanVien nhanVien;
        LoaiSach loaiSach;
        NhaXuatBan nhaXuatBan;
        NhaCungCap nhaCungCap;

        void LoadDoanhThu()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maHoaDon as [Mã hóa đơn], tenSach as [Tên sách], soLuong as [Số lượng], giaTien as [Giá tiền], ngayLap as [Ngày lập], giamGia as [Giảm giá] from HoaDon";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvDoanhThu.DataSource = data;

            double tongTienDT = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double soluong = Convert.ToDouble(data.Rows[i]["Số lượng"]);
                double giaTien = Convert.ToDouble(data.Rows[i]["Giá tiền"]);
                double giamGia = Convert.ToDouble(data.Rows[i]["Giảm giá"]);
                tongTienDT += soluong * giaTien * ((100 - giamGia) / 100);
            }

            txtTongTienChung.Text = tongTienDT.ToString();

        }
        void LoadSach()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maSach as [Mã Sách], tenSach as [Tên sách], soLuong as [Số lượng], giaTien as [Giá tiền], soTrang as [Số Trang], lanTaiBan as [Lần tái bản], namXuatBan as [Năm xuất bản], ngonNguSach as [Ngôn ngữ sách], moTa as [Mô tả], mauSach as [Màu Sách], boSach as [Bộ sách], tacGiaChinh as [Tác giả chính], tacGiaPhu as [Tác giả phụ] from Sach";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvSach.DataSource = data;

            string ak = "";
            if (data.Rows.Count <= 0)
            {
                ak = "SACH001";
            }
            else
            {
                int k;
                ak = "SACH";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(4, 3));
                k = k + 1;
                if (k < 10)
                {
                    ak = ak + "00";
                }
                else if (k < 100)
                {
                    ak = ak + "0";
                }
                ak = ak + k.ToString();
            }
            txtMaSachB.Text = ak.ToString();

        }
        void LoadKho()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maSach as [Mã Sách], tenSach as [Tên sách], soLuong as [Số lượng], tgNhapKho as [Thời gian nhập kho], tgXuatKho as [Thời gian xuất kho] from Kho";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvKho.DataSource = data;
            
            double sum = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double soluong = Convert.ToDouble(data.Rows[i]["Số lượng"]);
                if (soluong > 0)
                {
                    sum += soluong;
                }
            }
            txtSLSach.Text = sum.ToString();

            txtMaSachKho.Text = "SACH";
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
            dtgvDoanhThu.DataSource = data;

            // Tổng tiền hóa đơn
            double tongTien = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double soluong = Convert.ToDouble(data.Rows[i]["Số lượng"]);
                double giaTien = Convert.ToDouble(data.Rows[i]["Giá tiền"]);
                double giamGia = Convert.ToDouble(data.Rows[i]["Giảm giá"]);
                tongTien += soluong * giaTien * ((100 - giamGia) / 100);
            }
            txtTongTien.Text = tongTien.ToString();

            string ak = "";
            if (data.Rows.Count <= 0)
            {
                ak = "HD001";
            }
            else
            {
                int k;
                ak = "HD";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ak = ak + "00";
                }
                else if (k < 100)
                {
                    ak = ak + "0";
                }
                ak = ak + k.ToString();
            }
            txtMaHoaDon.Text = ak.ToString();
        }
        void LoadLoaiSach()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maSach as [Mã sách], theLoai as [Thể loại], doTuoi as [Độ tuổi] from LoaiSach";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvLoaiSach.DataSource = data;

            string ak = "";
            if (data.Rows.Count <= 0)
            {
                ak = "ND001";
            }
            else
            {
                int k;
                ak = "ND";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ak = ak + "00";
                }
                else if (k < 100)
                {
                    ak = ak + "0";
                }
                ak = ak + k.ToString();
            }
            txtMaLoaiSach.Text = ak.ToString();
        }
        void LoadNhaXuatBan()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maNXB as [Mã NXB], tenNXB as [Tên NXB] from NhaXuatBan";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvNXB.DataSource = data;



            string ak = "";
            if (data.Rows.Count <= 0)
            {
                ak = "NXB001";
            }
            else
            {
                int k;
                ak = "NXB";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(3, 3));
                k = k + 1;
                if (k < 10)
                {
                    ak = ak + "00";
                }
                else if (k < 100)
                {
                    ak = ak + "0";
                }
                ak = ak + k.ToString();
            }
            txtMaNXB.Text = ak.ToString();
        }
        void LoadNhaCungCap()
        {
            SqlConnection connection = new SqlConnection(connectSTR);
            String query = "Select maNCC as [Mã NCC], tenNCC as [Tên NCC] from NhaCungCap";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(data);
            connection.Close();
            dtgvNCC.DataSource = data;

            string ak = "";
            if (data.Rows.Count <= 0)
            {
                ak = "NCC001";
            }
            else
            {
                int k;
                ak = "NCC";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(3, 3));
                k = k + 1;
                if (k < 10)
                {
                    ak = ak + "00";
                }
                else if (k < 100)
                {
                    ak = ak + "0";
                }
                ak = ak + k.ToString();
            }
            txtMaNCC.Text = ak.ToString();
        }

        private void btnXReload_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Refresh();
            this.Hide();
            fDanhSachQuanLy f = new fDanhSachQuanLy();
            f.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fquanly b = new fquanly();
            b.ShowDialog();
            this.Close();
        }







        /*---------------------------------------------------------------------------------------------------------------------*/







        // Thao tác với tab DoanhThu
        private void txtDoanhThuThang_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtDoanhThuThang.Text.Trim();
            if (timKiem == "")
            {
                LoadDoanhThu();
            }
            else
            {
                //String query = "Select maHoaDon as [Mã hóa đơn], tenSach as [Tên sách], soLuong as [Số lượng], giaTien as [Giá tiền], ngayLap as [Ngày lập], giamGia as [Giảm giá] from HoaDon where month(ngayLap)  = '" + timKiem + "'";
                String query = "Select sum(soLuong*giaTien*(100-giamGia)/100) as [Tổng tiền] from HoaDon where month(ngayLap)  = '" + timKiem + "'";

                dtgvDoanhThu.DataSource = modify.Table(query);
            }
        }
        private void txtDoanhThuNam_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtDoanhThuNam.Text.Trim();
            if (timKiem == "")
            {
                LoadDoanhThu();
            }
            else
            {
                String query = "Select sum(soLuong*giaTien*(100-giamGia)/100) as [Tổng tiền] from HoaDon where year(ngayLap)  = '" + timKiem + "'";

                dtgvDoanhThu.DataSource = modify.Table(query);
            }
        }

        private void txtDoanhThuThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_+-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());
        }

        private void txtDoanhThuNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_+-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());
        }

        private void btnReloadDT_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Refresh();
            this.Hide();
            fDanhSachQuanLy f = new fDanhSachQuanLy();
            f.ShowDialog();
        }
   
        private void btnCTHD_Click(object sender, EventArgs e)
        {
            fChiTietHoaDon b = new fChiTietHoaDon();
            b.ShowDialog();
        }

        // Kết thúc tab DoanhThu









        /*-----------------------------------------------------------------------------------------------------------------*/








        // Thao tác với tab Kho

        private void DeleteTxtKho()
        {
            txtMaSachKho.Text = "";
            txtTenSachKho.Text = "";
            txtSoLuongKho.Text = "";
            txtTgNhapKho.Text = "";
            txtTgXuatKho.Text = "";
        }

        private bool CheckTxtKho()
        {
            if (txtMaSachKho.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sách");
                return false;
            }
            if (txtTenSachKho.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sách");
                return false;
            }
            if (txtSoLuongKho.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
                return false;
            }
            if (txtTgNhapKho.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thời gian nhập kho");
                return false;
            }
            if (txtTgXuatKho.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thời gian xuất kho");
                return false;
            }
            return true;
        }
        private void GetValuesTxtKho()
        {
            string maSachKho = txtMaSachKho.Text;
            string tenSachKho = txtTenSachKho.Text;
            string soLuongKho = txtSoLuongKho.Text;
            string tgNhapKho = txtTgNhapKho.Text;
            string tgXuatKho = txtTgXuatKho.Text;
            khoSach = new Kho(maSachKho, tenSachKho, soLuongKho, tgNhapKho, tgXuatKho);
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {
            if (CheckTxtKho())
            {
                GetValuesTxtKho();
                string query = "insert into Kho values('" + khoSach.MaSach + "', N'" + khoSach.TenSach + "','" + khoSach.SoLuong + "','" + khoSach.TgNhapKho + "','" + khoSach.TgXuatKho + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm thành công!");
                    DeleteTxtKho();
                    txtMaSachKho.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            if (dtgvKho.Rows.Count > 1)
            {

                if (CheckTxtKho())
                {
                    GetValuesTxtKho();
                    string query = "update Kho set maSach  = '" + khoSach.MaSach + "',tenSach= N'" + khoSach.TenSach + "',soLuong= '" + khoSach.SoLuong + "',tgNhapKho= '" + khoSach.TgNhapKho + "',tgXuatKho= '" + khoSach.TgXuatKho + "'";
                    query += " where maSach = '" + khoSach.MaSach + "'";
                    try
                    {
                        modify.Command(query);
                        MessageBox.Show("Cập nhật thông tin thành công!");
                        DeleteTxtKho();
                        txtMaSachKho.ReadOnly = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            if (dtgvKho.Rows.Count > 1)
            {
                string delete = dtgvKho.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete Kho";
                query += " where maSach = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin hóa đơn thành công!");
                    DeleteTxtKho();
                    txtMaSachKho.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }

        }

        private void txtSearchSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSearchSach.Text.Trim();
            if (timKiem == "")
            {
                LoadKho();
            }
            else
            {
                String query = "select * from Kho where maSach like '%" + timKiem + "%'";
                dtgvKho.DataSource = modify.Table(query);
            }
        }

        private void btnReloadKho_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSachKho.Text = dtgvKho.SelectedRows[0].Cells[0].Value.ToString();
            txtMaSachKho.ReadOnly = true;
            txtTenSachKho.Text = dtgvKho.SelectedRows[0].Cells[1].Value.ToString();
            txtSoLuongKho.Text = dtgvKho.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void txtSoLuongKho_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTgNhapKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_+-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());
        }

        private void txtTgXuatKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_+-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());

        }

        private void pcboxtgNhapkho_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn phải nhập thời gian nhập kho theo định dạng năm/tháng/ngày", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void pixboxTgXuatKho_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn phải nhập thời gian xuất kho theo định dạng năm/tháng/ngày", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {

            ViewReportKho formReport = new ViewReportKho();
            formReport.ShowDialog();
        }


        // Kết thúc tab Kho








     /*   ---------------------------------------------------------------------------------------------------------------------------*/










        // Thao tác với tab hóa đơn
        private void DeleteTxtHD()
        {
            txtMaHoaDon.Text = "";
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            txtGiaTien.Text = "";
            txtNgayLap.Text = "";
            txtGiamGia.Text = "";
        }
        
        private bool CheckTxtHD()
        {
            if(txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn");
                return false;
            }
            if (txtTenSach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sách");
                return false;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
                return false;
            }
            if (txtGiaTien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá tiền");
                return false;
            }
            if (txtNgayLap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày lập");
                return false;
            }
            if (txtGiamGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập phần trăm giảm giá");
                return false;
            }
            return true;
        }
        private void GetValuesTxtHD()
        {
            string maHoaDon = txtMaHoaDon.Text;
            string tenSach = txtTenSach.Text;
            string soLuong = txtSoLuong.Text;
            string giaTien = txtGiaTien.Text;
            string ngayLap = txtNgayLap.Text;
            string giamGia = txtGiamGia.Text;
            hoaDon = new HoaDon(maHoaDon, tenSach, soLuong, giaTien, ngayLap, giamGia);
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (CheckTxtHD())
            {
                GetValuesTxtHD();
                string query = "insert into HoaDon values('" + hoaDon.MaHoaDon + "', N'" + hoaDon.TenSach + "','" + hoaDon.SoLuong + "','" + hoaDon.GiaTien + "','" + hoaDon.NgayLap + "','" + hoaDon.GiamGia + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm thành công!");
                    DeleteTxtHD();
                    txtMaHoaDon.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }

        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDon.Rows.Count > 1)
            {

                if (CheckTxtHD())
                {
                    GetValuesTxtHD();
                    string query = "update HoaDon set maHoaDon  = '" + hoaDon.MaHoaDon + "',tenSach= N'" + hoaDon.TenSach + "',soLuong= '" + hoaDon.SoLuong + "',giaTien= '" + hoaDon.GiaTien + "',ngayLap= '" + hoaDon.NgayLap + "',giamGia= '" + hoaDon.GiamGia + "'";
                    query += " where maHoaDon = '" + hoaDon.MaHoaDon + "'";
                    try
                    {
                        modify.Command(query);
                        MessageBox.Show("Cập nhật thông tin thành công!");
                        DeleteTxtHD();
                        txtMaHoaDon.ReadOnly = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                    }
                }
            }
           
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Refresh();
            this.Hide();
            fDanhSachQuanLy f = new fDanhSachQuanLy();
            f.ShowDialog();

        }

        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHoaDon.Text = dtgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            txtMaHoaDon.ReadOnly = true;
            txtTenSach.Text = dtgvHoaDon.SelectedRows[0].Cells[1].Value.ToString();
            txtSoLuong.Text = dtgvHoaDon.SelectedRows[0].Cells[2].Value.ToString();
            txtGiaTien.Text = dtgvHoaDon.SelectedRows[0].Cells[3].Value.ToString();
            txtGiamGia.Text = dtgvHoaDon.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDon.Rows.Count > 1)
            {
                string delete = dtgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete HoaDon";
                query += " where maHoaDon = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin hóa đơn thành công!");
                    DeleteTxtHD();
                    txtMaHoaDon.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSearch.Text.Trim();
            if(timKiem == "")
            {
                LoadHoaDon();
            }
            else
            {
                String query = "Select maHoaDon as [Mã hóa đơn], tenSach as [Tên sách], soLuong as [Số lượng], giaTien as [Giá tiền], ngayLap as [Ngày lập], giamGia as [Giảm giá] from HoaDon where maHoaDon like '%" + timKiem + "%'";
                dtgvHoaDon.DataSource = modify.Table(query);
            }

        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNgayLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_+-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            int giamgia = 0;
            Int32.TryParse(txtGiamGia.Text, out giamgia);
            if (giamgia > 100 && txtGiamGia.Text != "")
            {
                MessageBox.Show("Phầm trăm giảm giá phải nhỏ hơn 100");
            }
        }
        private void picboxNgayLap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn phải nhập ngày lập hóa đơn theo định dạng năm/tháng/ngày", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void picboxGiamGia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần trăm giảm giá phải nhỏ hơn 100%", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
        private void btnReportHD_Click(object sender, EventArgs e)
        {
            ViewReportHD formReport = new ViewReportHD();
            formReport.ShowDialog();
        }
        // Kết thúc tab Hóa Đơn






        /* -----------------------------------------------------------------------*/






      
       



        /*   --------------------------------------------------------------------------------------------------------------------------*/




        // Thao tác với tab TimKiemSach
        private void DeleteTxtSach()
        {     
            txtMaSachB.Text = "";
            txtTenSachB.Text = "";
            txtSoLuongB.Text = "";
            txtGiaTienB.Text = "";
            txtSoTrang.Text = "";
            txtLanTB.Text = "";
            txtNamXB.Text = "";
            txtNNSach.Text = "";
            txtMoTa.Text = "";
            txtMauSach.Text = "";
            txtBoSach.Text = "";
            txtTacGiaChinh.Text = "";
            txtTacGiaPhu.Text = "";

        }

        private bool CheckTxtSach()
        {
            if (txtMaSachB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sách");
                return false;
            }
            if (txtTenSachB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sách");
                return false;
            }
            if (txtSoLuongB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng sách");
                return false;
            }
            if (txtGiaTienB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá tiền sách");
                return false;
            }
            if (txtSoTrang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số trang sách");
                return false;
            }
            if (txtLanTB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lần tái bản sách");
                return false;
            }
            if (txtNamXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm xuất bản sách");
                return false;
            }
            if (txtNNSach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngôn ngữ sách");
                return false;
            }
            if (txtMoTa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mô tả sách");
                return false;
            }
            if (txtMauSach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập màu sách");
                return false;
            }
            if (txtBoSach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập bộ sách");
                return false;
            }
            if (txtTacGiaChinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tác giả chính của sách");
                return false;
            }
            if (txtTacGiaPhu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tác giả phụ của sách");
                return false;
            }
            return true;
        }
        private void GetValuesTxtSach()
        {      
            string maSachB = txtMaSachB.Text;
            string tenSachB = txtTenSachB.Text;
            string soLuongB = txtSoLuongB.Text;
            string giaTienB = txtGiaTienB.Text;
            string soTrang = txtSoTrang.Text;
            string lanTB = txtLanTB.Text;
            string namXB = txtNamXB.Text;
            string ngonNguSach = txtNNSach.Text;
            string moTa = txtMoTa.Text;
            string mauSac = txtMauSach.Text;
            string boSach = txtBoSach.Text;
            string tacGiaChinh = txtTacGiaChinh.Text;
            string tacGiaPhu = txtTacGiaPhu.Text;
            sach = new Sach(maSachB, tenSachB, soLuongB, giaTienB, soTrang, lanTB, namXB, ngonNguSach, moTa, mauSac, boSach, tacGiaChinh, tacGiaPhu);
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (CheckTxtSach())
            {
                GetValuesTxtSach();
                string query = "insert into Sach values('" + sach.MaSach + "',N'" + sach.TenSach + "','" + sach.SoLuong + "','" + sach.GiaTien + "','" + sach.SoTrang + "', '" + sach.LanTaiBan + "','" + sach.NamXuatBan + "',N'" + sach.NgonNguSach + "', N'" + sach.MoTa + "', N'" + sach.MauSach + "', N'" + sach.BoSach + "', N'" + sach.TacGiaChinh + "', N'" + sach.TacGiaPhu + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm sách thành công!");
                    DeleteTxtSach();
                    txtMaSachB.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            if (CheckTxtSach())
            {
                GetValuesTxtSach();
                string query = "update Sach set maSach  = '" + sach.MaSach + "',tenSach= N'" + sach.TenSach + "',soLuong= N'" + sach.SoLuong + "',giaTien= '" + sach.GiaTien + "',soTrang= '" + sach.SoTrang + "',lanTaiBan= N'" + sach.LanTaiBan + "',NamXuatBan= '" + sach.NamXuatBan + "',ngonNguSach= '" + sach.NgonNguSach + "',moTa= '" + sach.MoTa + "',mauSach= '" + sach.MauSach + "',boSach= '" + sach.BoSach + "',tacGiaChinh= N'" + sach.TacGiaChinh + "',tacGiaPhu= N'" + sach.TacGiaPhu + "'";
                query += " where maSach = '" + sach.MaSach + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Cập nhật thông tin sách thành công!");
                    DeleteTxtSach();
                    txtMaSachB.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dtgvSach.Rows.Count > 1)
            {
                string delete = dtgvSach.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete Sach";
                query += " where maSach = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin sách thành công!");
                    DeleteTxtSach();
                    txtMaSachB.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnReloadSach_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Refresh();
            this.Hide();
            fDanhSachQuanLy f = new fDanhSachQuanLy();
            f.ShowDialog();
        }

        private void dtgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSachB.Text = dtgvSach.SelectedRows[0].Cells[0].Value.ToString();
            txtMaSachB.ReadOnly = true;
            txtTenSachB.Text = dtgvSach.SelectedRows[0].Cells[1].Value.ToString();
            txtSoLuongB.Text = dtgvSach.SelectedRows[0].Cells[2].Value.ToString();
            txtGiaTienB.Text = dtgvSach.SelectedRows[0].Cells[3].Value.ToString();
            txtSoTrang.Text = dtgvSach.SelectedRows[0].Cells[4].Value.ToString();
            txtLanTB.Text = dtgvSach.SelectedRows[0].Cells[5].Value.ToString();
            txtNamXB.Text = dtgvSach.SelectedRows[0].Cells[6].Value.ToString();
            txtNNSach.Text = dtgvSach.SelectedRows[0].Cells[7].Value.ToString();
            txtMoTa.Text = dtgvSach.SelectedRows[0].Cells[8].Value.ToString();
            txtMauSach.Text = dtgvSach.SelectedRows[0].Cells[9].Value.ToString();
            txtBoSach.Text = dtgvSach.SelectedRows[0].Cells[10].Value.ToString();
            txtTacGiaChinh.Text = dtgvSach.SelectedRows[0].Cells[11].Value.ToString();
            txtTacGiaPhu.Text = dtgvSach.SelectedRows[0].Cells[12].Value.ToString();
        }

        private void txtSMaSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSMaSach.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where maSach like '%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSTenSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSTenSach.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where tenSach like N'%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSNNSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSNNSach.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where ngonNguSach like N'%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSMauSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSMauSach.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where mauSach like N'%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSBoSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSBoSach.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where BoSach like N'%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSNamXB_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSNamXB.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where namXuatBan like '%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSTgChinh_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSTgChinh.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where tacGiaChinh like N'%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSTgPhu_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSTgPhu.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where tacGiaPHu like N'%" + timKiem + "%'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSGiaSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSGiaSach.Text.Trim();
            if (timKiem == "")
            {
                LoadSach();
            }
            else
            {
                String query = "select * from Sach where giaTien <= '" + timKiem + "'";
                dtgvSach.DataSource = modify.Table(query);
            }
        }

        private void txtSoLuongB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaTienB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoTrang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLanTB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNamXB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSNamXB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSGiaSach_KeyPress(object sender, KeyPressEventArgs e)
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


        private void txtMaSachB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSachB.Text))
            {
                btnXoaSach.Enabled = false; 
            }
            else
            {
                btnXoaSach.Enabled = true;
            }
        }

        private void txtMaSachKho_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSachKho.Text))
            {
                btnXoaKho.Enabled = false;
            }
            else
            {
                btnXoaKho.Enabled = true;
            }
        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                btnXoaHD.Enabled = false;
            }
            else
            {
                btnXoaHD.Enabled = true;
            }
        }


        // Kết thúc tab TimKiemSach







       /* -----------------------------------------------------------------------------------------------------------------*/






        // Thao tác với tab Khac
        private void GetValuesTxtLS()
        {
            string maLoaiSach = txtMaLoaiSach.Text;
            string theLoai = txtTheLoai.Text;
            string doTuoi = txtDoTuoi.Text;
            loaiSach = new LoaiSach(maLoaiSach, theLoai, doTuoi);

        }
        private void DeleteTxtLS()
        {
            txtMaLoaiSach.Text = "";
            txtTheLoai.Text = "";
            txtDoTuoi.Text = "";
        }
        private bool CheckTxtLS()
        {
            /*if (txtMaLoaiSach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại sách");
                return false;
            }*/
            if (txtTheLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thể loại sách");
                return false;
            }
            if (txtDoTuoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập độ tuổi khuyến nghị của sách");
                return false;
            }
            return true;
        }
        private void GetValuesTxtNXB()
        {
            string maNXB = txtMaNXB.Text;
            string tenNXB = txtTenNXB.Text;
            nhaXuatBan = new NhaXuatBan(maNXB, tenNXB);

        }
        private void DeleteTxtNXB()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
        }
        private bool CheckTxtNXB()
        {
            if (txtMaNXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà xuất bản");
                return false;
            }
            if (txtTenNXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà xuất bản");
                return false;
            }
            return true;
        }
        private void GetValuesTxtNCC() 
        { 
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            nhaCungCap = new NhaCungCap(maNCC, tenNCC);
        }
        private void DeleteTxtNCC() 
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
        }
        private bool CheckTxtNCC() 
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp");
                return false;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp");
                return false;
            }
            return true;
        }
        private void btnThemLS_Click(object sender, EventArgs e)
        {
            if (CheckTxtLS())
            {
                GetValuesTxtLS();
                string query = "insert into LoaiSach values('" + loaiSach.MaSach + "',N'" + loaiSach.TheLoai + "','" + loaiSach.DoTuoi + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm thể loại sách thành công!");
                    DeleteTxtLS();
                    txtMaLoaiSach.ReadOnly = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }

        }

        private void btnXoaLS_Click(object sender, EventArgs e)
        {
            if (dtgvLoaiSach.Rows.Count > 1)
            {
                string delete = dtgvLoaiSach.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete LoaiSach";
                query += " where maSach = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin loại sách thành công!");
                    DeleteTxtSach();
                    txtMaLoaiSach.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnSuaLS_Click(object sender, EventArgs e)
        {
            if (CheckTxtLS())
            {
                GetValuesTxtLS();
                string query = "update LoaiSach set maSach  = '" + loaiSach.MaSach + "',theLoai= N'" + loaiSach.TheLoai + "',doTuoi= N'" + loaiSach.DoTuoi + "'";
                query += " where maSach = '" + loaiSach.MaSach + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Cập nhật thể loại sách thành công!");
                    DeleteTxtLS();
                    txtMaLoaiSach.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        
        private void btnSuaNXB_Click(object sender, EventArgs e)
        {
            if (CheckTxtLS())
            {
                GetValuesTxtLS();
                string query = "update LoaiSach set maSach  = '" + loaiSach.MaSach + "',theLoai= N'" + loaiSach.TheLoai + "',doTuoi= N'" + loaiSach.DoTuoi + "'";
                query += " where maSach = '" + loaiSach.MaSach + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Cập nhật thể loại sách thành công!");
                    DeleteTxtSach();
                    txtMaLoaiSach.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            if (CheckTxtNXB())
            {
                GetValuesTxtNXB();
                string query = "insert into NhaXuatBan values('" + nhaXuatBan.MaNXB + "',N'" + nhaXuatBan.TenNXB + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm nhà xuất bản thành công!");
                    DeleteTxtNXB();
                    txtMaNXB.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        private void btnSuaNXB_Click_1(object sender, EventArgs e)
        {
            if (CheckTxtNXB())
            {
                GetValuesTxtNXB();
                string query = "update NhaXuatBan set maNXB  = '" + nhaXuatBan.MaNXB + "',tenNXB= N'" + nhaXuatBan.TenNXB + "'";
                query += " where maNXB = '" + nhaXuatBan.MaNXB + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Cập nhật thể loại sách thành công!");
                    DeleteTxtNXB();
                    txtMaNXB.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            if (dtgvNXB.Rows.Count > 1)
            {
                string delete = dtgvNXB.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete NhaXuatBan";
                query += " where maNXB = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin loại sách thành công!");
                    DeleteTxtNXB();
                    txtMaNXB.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (CheckTxtNCC())
            {
                GetValuesTxtNCC();
                string query = "insert into NhaCungCap values('" + nhaCungCap.MaNCC + "',N'" + nhaCungCap.TenNCC + "')";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    DeleteTxtNCC();
                    txtMaNCC.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (CheckTxtNCC())
            {
                GetValuesTxtNCC();
                string query = "update NhaCungCap set maNCC  = '" + nhaCungCap.MaNCC + "',tenNCC= N'" + nhaCungCap.TenNCC +  "'";
                query += " where maNCC = '" + nhaCungCap.MaNCC + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Cập nhật thông nhà cung cấp thành công!");
                    DeleteTxtNCC();
                    txtMaNCC.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (dtgvNCC.Rows.Count > 1)
            {
                string delete = dtgvNCC.SelectedRows[0].Cells[0].Value.ToString();
                string query = "delete NhaCungCap";
                query += " where maNCC = '" + delete + "'";
                try
                {
                    modify.Command(query);
                    MessageBox.Show("Bạn đã xóa thông tin nhà cung cấp thành công!");
                    DeleteTxtNCC();
                    txtMaNCC.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void txtSMLoaiSach_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSMLoaiSach.Text.Trim();
            if (timKiem == "")
            {
                LoadLoaiSach();
            }
            else
            {
                String query = "select * from LoaiSach where maSach like '%" + timKiem + "%'";
                dtgvLoaiSach.DataSource = modify.Table(query);
            }
        }

        private void txtSDoTuoi_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSDoTuoi.Text.Trim();
            if (timKiem == "")
            {
                LoadLoaiSach();
            }
            else
            {
                String query = "select * from LoaiSach where doTuoi like '%" + timKiem + "%'";
                dtgvLoaiSach.DataSource = modify.Table(query);
            }
        }
        private void txtSTheLoai_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSTheLoai.Text.Trim();
            if (timKiem == "")
            {
                LoadLoaiSach();
            }
            else
            {
                String query = "select * from LoaiSach where theLoai like '%" + timKiem + "%'";
                dtgvLoaiSach.DataSource = modify.Table(query);
            }
        }

        private void txtSNCC_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSNCC.Text.Trim();
            if (timKiem == "")
            {
                LoadNhaCungCap();
            }
            else
            {
                String query = "select * from NhaCungCap where maNCC like '%" + timKiem + "%'";
                dtgvNCC.DataSource = modify.Table(query);
            }
        }
        private void txtSNXB_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtSNXB.Text.Trim();
            if (timKiem == "")
            {
                LoadNhaXuatBan();
            }
            else
            {
                String query = "select * from NhaXuatBan where maNXB like '%" + timKiem + "%'";
                dtgvNXB.DataSource = modify.Table(query);
            }
        }

        private void dtgvLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoaiSach.Text = dtgvLoaiSach.SelectedRows[0].Cells[0].Value.ToString();
            txtMaLoaiSach.ReadOnly = true; 
            txtTheLoai.Text = dtgvLoaiSach.SelectedRows[0].Cells[1].Value.ToString();
            txtDoTuoi.Text = dtgvLoaiSach.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void dtgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNXB.Text = dtgvNXB.SelectedRows[0].Cells[0].Value.ToString();
            txtMaNXB.ReadOnly = true;
            txtTenNXB.Text = dtgvNXB.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dtgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dtgvNCC.SelectedRows[0].Cells[0].Value.ToString();
            txtMaNCC.ReadOnly = true;
            txtTenNCC.Text = dtgvNCC.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void txtDoTuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "`!@#$%^&*()_-=qwertyuiop[]asdfghjkl;'zxcvbnm{,}QWERTYUIOPASDFGHJKLZXCVBNM".Contains(e.KeyChar.ToString());

        }

        private void txtMaLoaiSach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiSach.Text))
            {
                btnXoaLS.Enabled = false;
            }
            else
            {
                btnXoaLS.Enabled = true;
            }
        }

        private void txtMaNXB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNXB.Text))
            {
                btnXoaNXB.Enabled = false;
            }
            else
            {
                btnXoaNXB.Enabled = true;
            }
        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                btnXoaNCC.Enabled = false;
            }
            else
            {
                btnXoaNCC.Enabled = true;
            }
        }

       
    }

    // Kết thúc thao tác với tab Khac
}
