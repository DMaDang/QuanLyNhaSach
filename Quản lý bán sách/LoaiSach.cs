using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class LoaiSach
    {
        private string maSach;
        private string theLoai;
        private string doTuoi;

        public LoaiSach(string maSach, string theLoai, string doTuoi)
        {
            this.maSach = maSach;
            this.theLoai = theLoai;
            this.doTuoi = doTuoi;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public string DoTuoi { get => doTuoi; set => doTuoi = value; }
    }
}
