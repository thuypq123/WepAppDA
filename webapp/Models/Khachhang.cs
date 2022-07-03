using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Gopies = new HashSet<Gopy>();
            Hoadons = new HashSet<Hoadon>();
            Hosos = new HashSet<Hoso>();
            Tokhais = new HashSet<Tokhai>();
        }

        public int Makh { get; set; }
        [StringLength(50, ErrorMessage = "Tên khách hàng không được quá 50 ký tự")]
        [DisplayName("Khách hàng")]
        [Required]
        public string Tenkh { get; set; }
        [StringLength(11, ErrorMessage = "SĐT không được quá 11 ký tự")]
        [DisplayName("SĐT")]
        [Required]
        public string Sdt { get; set; }
        [StringLength(20, ErrorMessage = "CMND không được quá 20 ký tự")]
        [DisplayName("CMND")]
        [Required]
        public string Cmnd { get; set; }
        [StringLength(50, ErrorMessage = "Địa chỉ không được quá 50 ký tự")]
        [DisplayName("Địa chỉ")]
        [Required]
        public string Diachi { get; set; }
        [StringLength(50, ErrorMessage = "Email không được quá 50 ký tự")]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string Anhdaidien { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [StringLength(25, ErrorMessage = "Tài khoản không được quá 25 ký tự")]
        [DisplayName("Tài khoản")]
        [Required]
        public string Tk { get; set; }
        [StringLength(25, ErrorMessage = "Mật khẩu không được quá 25 ký tự")]
        [DisplayName("Mật khẩu")]
        [Required]
        public string Mk { get; set; }
        [StringLength(5, ErrorMessage = "Giới tính không được quá 5 ký tự")]
        [DisplayName("Giới tính")]
        [Required]
        public string Gioitinh { get; set; }
        public int Maqt { get; set; }
        public int Madt { get; set; }

        [DisplayName("Dân tộc")]
        public virtual Dantoc MadtNavigation { get; set; }
        [DisplayName("Quốc tịch")]
        public virtual Quoctich MaqtNavigation { get; set; }
        public virtual ICollection<Gopy> Gopies { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<Hoso> Hosos { get; set; }
        public virtual ICollection<Tokhai> Tokhais { get; set; }
    }
}
