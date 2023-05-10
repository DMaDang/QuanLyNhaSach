using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_bán_sách
{
    class Sach
    {
        private string maSach;
        private string tenSach;
        private string soLuong;
        private string giaTien;
        private string soTrang;
        private string lanTaiBan;
        private string namXuatBan;
        private string ngonNguSach;
        private string moTa;
        private string mauSach;
        private string boSach;
        private string tacGiaChinh;
        private string tacGiaPhu;

        public Sach(string maSach, string tenSach, string soLuong, string giaTien, string soTrang, string lanTaiBan, string namXuatBan, string ngonNguSach, string moTa, string mauSach, string boSach, string tacGiaChinh, string tacGiaPhu)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
            this.soTrang = soTrang;
            this.lanTaiBan = lanTaiBan;
            this.namXuatBan = namXuatBan;
            this.ngonNguSach = ngonNguSach;
            this.moTa = moTa;
            this.mauSach = mauSach;
            this.boSach = boSach;
            this.tacGiaChinh = tacGiaChinh;
            this.tacGiaPhu = tacGiaPhu;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string GiaTien { get => giaTien; set => giaTien = value; }
        public string SoTrang { get => soTrang; set => soTrang = value; }
        public string LanTaiBan { get => lanTaiBan; set => lanTaiBan = value; }
        public string NamXuatBan { get => namXuatBan; set => namXuatBan = value; }
        public string NgonNguSach { get => ngonNguSach; set => ngonNguSach = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSach { get => mauSach; set => mauSach = value; }
        public string BoSach { get => boSach; set => boSach = value; }
        public string TacGiaChinh { get => tacGiaChinh; set => tacGiaChinh = value; }
        public string TacGiaPhu { get => tacGiaPhu; set => tacGiaPhu = value; }
    }
}
