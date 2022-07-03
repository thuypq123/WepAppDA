using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Tkadmin
    {
        public Tkadmin()
        {
            Blogs = new HashSet<Blog>();
        }
        [StringLength(25, ErrorMessage = "Tài khoản không được quá 25 ký tự")]
        [DisplayName("Tài khoản")]
        [Required]
        public string Tk { get; set; }
        [StringLength(25, ErrorMessage = "Mật khẩu không được quá 25 ký tự")]
        [DisplayName("Mật khẩu")]
        [Required]
        public string Mk { get; set; }
        [StringLength(35, ErrorMessage = "Họ tên không được quá 35 ký tự")]
        [DisplayName("Họ tên")]
        [Required]
        public string Hoten { get; set; }
        [StringLength(50, ErrorMessage = "Email không được quá 50 ký tự")]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
