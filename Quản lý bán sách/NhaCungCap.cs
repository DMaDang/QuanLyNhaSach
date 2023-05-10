using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class NhaCungCap
    {
        private string maNCC;
        private string tenNCC;

        public NhaCungCap(string maNCC, string tenNCC)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
        }

        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
    }
}
