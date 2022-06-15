using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class CtHoadon
    {
        public int Masp { get; set; }
        public int Mdhd { get; set; }
        public int? Dongia { get; set; }
        public short? Soluong { get; set; }

        public virtual Sanpham MaspNavigation { get; set; }
        public virtual Hoadon MdhdNavigation { get; set; }
    }
}
