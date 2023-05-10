using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class ChiTietHoaDon
    {
        private string maSach;
        private string maHoaDon;
        private string soLuong;
        private string thanhTien;

        public ChiTietHoaDon(string maSach, string maHoaDon, string soLuong, string thanhTien)
        {
            this.maSach = maSach;
            this.maHoaDon = maHoaDon;
            this.soLuong = soLuong;
            this.thanhTien = thanhTien;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
