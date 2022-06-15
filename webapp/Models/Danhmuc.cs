using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Madm { get; set; }
        public string Tendm { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
