using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class HoaDon
    {
        private string maHoaDon;
        private string tenSach;
        private string soLuong;
        private string giaTien;
        private string ngayLap;
        private string giamGia;

        public HoaDon(string maHoaDon, string tenSach, string soLuong, string giaTien, string ngayLap, string giamGia)
        {
            this.maHoaDon = maHoaDon;
            this.tenSach = tenSach;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
            this.ngayLap = ngayLap;
            this.giamGia = giamGia;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string GiaTien { get => giaTien; set => giaTien = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public string GiamGia { get => giamGia; set => giamGia = value; }
    }
}
