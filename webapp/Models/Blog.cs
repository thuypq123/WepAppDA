using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Blog
    {
        public int Mablog { get; set; }
        public string Tk { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaydang { get; set; }
        public string Anh { get; set; }

        public virtual Admin TkNavigation { get; set; }
    }
}
