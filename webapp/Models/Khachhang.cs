using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Gopies = new HashSet<Gopy>();
            Hoadons = new HashSet<Hoadon>();
            Hosos = new HashSet<Hoso>();
            Tokhais = new HashSet<Tokhai>();
        }

        public int Makh { get; set; }
        public string Tenkh { get; set; }
        public string Sdt { get; set; }
        public string Cmnd { get; set; }
        public string Diachi { get; set; }
        public string Anhdaidien { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Tk { get; set; }
        public string Mk { get; set; }
        public string Gioitinh { get; set; }
        public int Maqt { get; set; }
        public int Madt { get; set; }

        public virtual Dantoc MadtNavigation { get; set; }
        public virtual Quoctich MaqtNavigation { get; set; }
        public virtual ICollection<Gopy> Gopies { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<Hoso> Hosos { get; set; }
        public virtual ICollection<Tokhai> Tokhais { get; set; }
    }
}
