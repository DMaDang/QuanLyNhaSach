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
    public partial class fquanly : Form
    {
        bool isExit = true;
        private int len = 0;
        private string text;
        
        public fquanly()
        {
            InitializeComponent();
        }
       
        private void tsmDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap b = new fDangNhap();
            b.ShowDialog();
            this.Close();
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            if (isExit)
                this.Close();
        }

      

        private void tsmDoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDoiMatKhau b = new fDoiMatKhau();
            b.ShowDialog();
            this.Close();
        }

        private void tsmQuanLy_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDanhSachQuanLy b = new fDanhSachQuanLy();
            b.ShowDialog();
            this.Close();
        }

        private void tsmTTLH_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hotline: 0378483611 - Mr.Dang \nEmail: dmdang1203@gmail.com", "Thông tin liên hệ");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }
       
        private void fquanly_Load(object sender, EventArgs e)
        {
            timer1.Start();
            text = lblSach.Text;
            lblSach.Text = "";
            timer2.Start();
        }
        int x;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (len < text.Length)
            {
                lblSach.Text = lblSach.Text + text.ElementAt(len);
                len++;
            }
            else
            {
                timer2.Stop();
            }

        }

        private void lblSach_Click(object sender, EventArgs e)
        {

        }
    }
}
