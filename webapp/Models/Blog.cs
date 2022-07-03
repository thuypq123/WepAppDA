using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Blog
    {
        public int Mablog { get; set; }
        public string Tk { get; set; }
        [StringLength(100, ErrorMessage = "Tiêu đề không quá 100 ký tự")]
        [DisplayName("Tiêu đề")]
        [Required]
        public string Tieude { get; set; }
        [Required]
        [DisplayName("Nội dung")]
        [StringLength(500, ErrorMessage = "Nội dung không quá 500 ký tự")]
        public string Noidung { get; set; }
        [DisplayName("Ngày đăng")]
        public DateTime? Ngaydang { get; set; }
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [DisplayName("Tài khoản")]
        public virtual Tkadmin TkNavigation { get; set; }
    }
}
