using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            CtHoadons = new HashSet<CtHoadon>();
        }

        public int Mdhd { get; set; }
        public int Makh { get; set; }
        public DateTime? Ngaylap { get; set; }
        public decimal? Tongtien { get; set; }
        public bool? Tinhtranggiaohang { get; set; }
        public bool? Tinhtrangthanhtoan { get; set; }
        public string Nguoinhan { get; set; }
        public string Diachinhan { get; set; }
        public string Sdtnhan { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
        public virtual ICollection<CtHoadon> CtHoadons { get; set; }
    }
}
