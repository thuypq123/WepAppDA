using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            CtHoadons = new HashSet<CtHoadon>();
        }

        public int Masp { get; set; }
        public int Madm { get; set; }
        public string Tensp { get; set; }
        public short? Soluong { get; set; }
        public int? Dongia { get; set; }
        public string Img { get; set; }
        public string Thongtin { get; set; }

        public virtual Danhmuc MadmNavigation { get; set; }
        public virtual ICollection<CtHoadon> CtHoadons { get; set; }
    }
}
