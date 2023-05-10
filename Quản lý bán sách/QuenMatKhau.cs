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
    public partial class fQuenMatKhau : Form
    {
        public fQuenMatKhau()
        {
            InitializeComponent();
            lblMatKhau.Text = ""; 
        }
        Modify modify = new Modify();

        private void btn_GetPass_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text.Trim();
            if(email == "")
            {
                MessageBox.Show("Vui lòng nhập đúng Email đã đăng ký.");
            }
            else
            {
                String query = "Select * from QuanLyTaiKhoan where Email = '" + email + "'";
                if (modify.DanhSachTaiKhoans(query).Count != 0)
                {
                    lblMatKhau.ForeColor = Color.Blue;
                    lblMatKhau.Text = "Mật khẩu: " + modify.DanhSachTaiKhoans(query)[0].Passwork;
                }
                else
                {
                    lblMatKhau.ForeColor = Color.Red;
                    lblMatKhau.Text = "Email này chưa được đăng ký!";
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
