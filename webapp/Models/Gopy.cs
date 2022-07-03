using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Gopy
    {
        public int Magy { get; set; }
        public string Noidung { get; set; }
        public bool? Tinhtrang { get; set; }
        public string Tieude { get; set; }
        public int Makh { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
    }
}
