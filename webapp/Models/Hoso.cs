using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Hoso
    {
        public int Mahs { get; set; }
        public DateTime? Ngaylap { get; set; }
        public string Khuvuc { get; set; }
        public short? Tinhtrang { get; set; }
        public int Makh { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
    }
}
