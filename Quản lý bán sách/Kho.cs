using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class Kho
    {
        private string maSach;
        private string tenSach;
        private string soLuong;
        private string tgNhapKho;
        private string tgXuatKho;

        public Kho(string maSach, string tenSach, string soLuong, string tgNhapKho, string tgXuatKho)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.soLuong = soLuong;
            this.tgNhapKho = tgNhapKho;
            this.tgXuatKho = tgXuatKho;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string TgNhapKho { get => tgNhapKho; set => tgNhapKho = value; }
        public string TgXuatKho { get => tgXuatKho; set => tgXuatKho = value; }
    }
}
