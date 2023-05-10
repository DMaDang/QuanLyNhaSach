using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class DanhSachTaiKhoan
    {
        private string user;
        private string passwork;

        public DanhSachTaiKhoan()
        {

        }

        public DanhSachTaiKhoan(string user, string passwork)
        {
            this.user = user;
            this.passwork = passwork;
        }

        public string User { get => user; set => user = value; }
        public string Passwork { get => passwork; set => passwork = value; }
    }
}
