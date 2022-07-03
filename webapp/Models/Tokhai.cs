using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Tokhai
    {
        public int Matokhai { get; set; }
        [StringLength(50, ErrorMessage = " Đi những đâu không được quá 50 ký tự")]
        [DisplayName("Đi những đâu")]
        [Required]
        public string Dinhungdau { get; set; }
        [StringLength(50, ErrorMessage = "Triệu trứng không được quá 50 ký tự")]
        [DisplayName("Triệu chứng")]
        [Required]
        public string Trieuchung { get; set; }
        [DisplayName("Tiếp xúc người bệnh")]
        public bool? Txnguoibenh { get; set; }
        [DisplayName("Tiếp xúc người nước bệnh")]
        public bool? Txnguoinuocbenh { get; set; }
        [DisplayName("Người có biểu hiện")]
        public bool? Nguoicobieuhien { get; set; }
        [DisplayName("Khách hàng")]
        public int Makh { get; set; }

        [DisplayName("Khách hàng")]
        public virtual Khachhang MakhNavigation { get; set; }
    }
}
