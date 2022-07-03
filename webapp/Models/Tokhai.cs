using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Tokhai
    {
        public int Matokhai { get; set; }
        public string Dinhungdau { get; set; }
        public string Trieuchung { get; set; }
        public bool? Txnguoibenh { get; set; }
        public bool? Txnguoinuocbenh { get; set; }
        public bool? Nguoicobieuhien { get; set; }
        public int Makh { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
    }
}