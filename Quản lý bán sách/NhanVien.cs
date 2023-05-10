using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class NhanVien
    {
        private string maNhanVien;
        private string userName;
        private string tenNhanVien;
        private string congViec;
        private string diaChi;
        private string gioiTinh;
        private string ngaySinh;
        private string email;
        private string luong;

        public NhanVien(string maNhanVien, string userName, string tenNhanVien, string congViec, string diaChi, string gioiTinh, string ngaySinh, string email, string luong)
        {
            this.maNhanVien = maNhanVien;
            this.userName = userName;
            this.tenNhanVien = tenNhanVien;
            this.congViec = congViec;
            this.diaChi = diaChi;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.email = email;
            this.luong = luong;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string UserName { get => userName; set => userName = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string CongViec { get => congViec; set => congViec = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public string Luong { get => luong; set => luong = value; }
    }
}
