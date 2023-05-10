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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void tsmDangNhap_Click(object sender, EventArgs e)
        {
            {
                fDangNhap a = new fDangNhap();
                a.MdiParent = this;
                a.Show();
            }
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void tsmDangKy_Click(object sender, EventArgs e)
        {
            {
                MessageBox.Show("Phải đăng nhập với tư cách quản trị viên mới có thể đăng ký tài khoản.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void tsmDoiMatKhau_Click(object sender, EventArgs e)
        {
            {
                fDoiMatKhau c = new fDoiMatKhau();
                c.MdiParent = this;
                c.Show();
            }
        }

        private void tsmQuenMatKhau_Click(object sender, EventArgs e)
        {
            {
                fQuenMatKhau f = new fQuenMatKhau();
                f.MdiParent = this;
                f.Show();
            }
        }
        int x;
        private void timer1_Tick(object sender, EventArgs e)
           
        {
           /* x = label1.Location.X;
            x--;
            label1.Location = new Point(x, label1.Location.Y);


            if (x == 0)
            {
                fMain f = new fMain();
                x = f.Size.Width;
                label1.Location = new Point(f.Size.Width, label1.Location.Y);
            }*/
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fMain_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
   
    }

}
