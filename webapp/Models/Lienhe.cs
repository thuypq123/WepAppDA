using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Lienhe
    {
        public int Malh { get; set; }
        [StringLength(50, ErrorMessage = "Địa chỉ không được quá 50 ký tự")]
        [DisplayName("Địa chỉ")]
        [Required]
        public string Diachi { get; set; }
        [StringLength(11, ErrorMessage = "SĐT không được quá 11 ký tự")]
        [DisplayName("SĐT")]
        [Required]
        public string Sdt { get; set; }
        [StringLength(50, ErrorMessage = "Email không được quá 50 ký tự")]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "Facebook không được quá 50 ký tự")]
        [DisplayName("Facebook")]
        [Required]
        public string Facebook { get; set; }
    }
}
