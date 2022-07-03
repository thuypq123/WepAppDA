using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class GioHang
    {
        covid19Context context = new covid19Context();

        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string IMG { get; set; }
        public int SoLuong { get; set; }
        public int? DonGia { get; set; }
        public int? ThanhTien
        {
            get { return SoLuong * DonGia; }
        }

        public GioHang(int masp)
        {
            MaSP = masp;
            Sanpham sanpham = context.Sanphams.Single(sp => sp.Masp == MaSP);
            TenSP = sanpham.Tensp;
            IMG = sanpham.Img;
            DonGia = sanpham.Dongia;
            SoLuong = 1;
        }
    }
}
