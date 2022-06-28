using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Blog
    {
        
        public int Mablog { get; set; }
        public string Tk { get; set; }
        [StringLength(255)]
        public string Tieude { get; set; }
        [StringLength(255)]
        public string Noidung { get; set; }
        public DateTime? Ngaydang { get; set; }
        public string Anh { get; set; }

        public virtual Tkadmin TkNavigation { get; set; }
    }
}
