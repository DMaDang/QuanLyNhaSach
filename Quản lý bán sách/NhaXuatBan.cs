using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class NhaXuatBan
    {
        private string maNXB;
        private string tenNXB;

        public NhaXuatBan(string maNXB, string tenNXB)
        {
            this.maNXB = maNXB;
            this.tenNXB = tenNXB;
        }

        public string MaNXB { get => maNXB; set => maNXB = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
    }
}
