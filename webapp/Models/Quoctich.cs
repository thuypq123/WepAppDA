using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Quoctich
    {
        public Quoctich()
        {
            Khachhangs = new HashSet<Khachhang>();
        }

        public int Maqt { get; set; }
        public string Tenqt { get; set; }

        public virtual ICollection<Khachhang> Khachhangs { get; set; }
    }
}
