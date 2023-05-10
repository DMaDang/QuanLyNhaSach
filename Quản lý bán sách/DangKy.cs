using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_sách
{
    public partial class fDangKy : Form
    {
        public fDangKy()
        {
            InitializeComponent();
        }
        public bool checkAccount(String account)
        {
            return Regex.IsMatch(account,"^[a-zA-Z0-9]{4,24}$");
        }
        public bool checkEmail(String email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com$");
        }
        Modify modify = new Modify();
        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            String user = txtUser.Text.Trim();
            String passwork = txtPass.Text.Trim();
            String rePasswork = txtRePass.Text.Trim();
            String email = txtEmail.Text.Trim();
            if (!checkAccount(user))
            {
                MessageBox.Show("Tài khooản sai định dạng");
                return;
            }
            if (!checkAccount(passwork))
            {
                MessageBox.Show("Mật khẩu sai định dạng");
                return;
            }
            if(rePasswork != passwork)
            {
                MessageBox.Show("Vui lòng xác nhận chính xác mật khẩu");
            }
            if (!checkEmail(email)) 
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email");
                return;
            }
            if(modify.DanhSachTaiKhoans("Select * from QuanLyTaiKhoan where Email = '" + email + "'").Count!=0)
            {
                MessageBox.Show("Email này đã tồn tại");
                return; 
            }
            try
            {
                String query = "insert into QuanLyTaiKhoan values('" + user + "','" + passwork + "','" + email + "')";
                modify.Command(query);
                if(MessageBox.Show("Bạn đã đăng ký tài khoản thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tài khoản đã tồn tại, vui lòng đăng ký tài khoản khác.");
            }


        }

        private void lblDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            fDangNhap b = new fDangNhap();
            b.ShowDialog();
            this.Close();
        }

        private void lblThoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
