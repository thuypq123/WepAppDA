using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Gopy
    {
        public int Magy { get; set; }
        [StringLength(100, ErrorMessage = "Nội dung không được quá 100 ký tự")]
        [DisplayName("Nội dung")]
        [Required]
        public string Noidung { get; set; }
        [DisplayName("Tình trạng")]
        public bool? Tinhtrang { get; set; }
        [StringLength(50, ErrorMessage = "Tiêu đề không được quá 30 ký tự")]
        [DisplayName("Tiêu đề")]
        [Required]
        public string Tieude { get; set; }
        public int Makh { get; set; }

        [DisplayName("Khách hàng")]
        public virtual Khachhang MakhNavigation { get; set; }
    }
}
