using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_sách
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String user = txtUser.Text.Trim();
            String password = txtPass.Text.Trim();
            if (user== "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập");
                return;
            }
            else if(password== "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            else
            {
                string query = "Select * from QuanLyTaiKHoan where TenDangNhap = '" + user + "' and MatKhau ='" + password + "'";
                if (user == "admin" && password == "123456")
                {
                    MessageBox.Show("Chào mừng bạn");
                    this.Hide();
                    fAdmin f = new fAdmin();
                    f.ShowDialog();
                    this.Close();
                }
                else if (modify.DanhSachTaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Chào mừng bạn");
                    this.Hide();
                    fquanly f = new fquanly();
                    f.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập");
                }
            }
           

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            //{
             //   e.Cancel = true;
            //}
        }

        private void lblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                this.Hide();
                fDangKy b = new fDangKy();
                b.ShowDialog();
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                fQuenMatKhau f = new fQuenMatKhau();
                f.ShowDialog();
            }
        }

        private void chkhtmk_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkhtmk.Checked)
            {
                txtPass.PasswordChar = '*';
            }
            if (chkhtmk.Checked) 
            {
                txtPass.PasswordChar = '\0';
            }

        }

        private void picboxLuuY_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tùy vào thông tin đăng nhập sẽ dẫn bạn đến trang Admin hoặc trang của nhân viên.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
    }
}
