using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            CtHoadons = new HashSet<CtHoadon>();
        }

        public int Masp { get; set; }
        [DisplayName("Danh mục")]
        public int Madm { get; set; }
        [StringLength(40, ErrorMessage = "Tên sản phẩm không được quá 40 ký tự")]
        [DisplayName("Sản phẩm")]
        [Required]
        public string Tensp { get; set; }
        
        [DisplayName("Số lượng")]
        [Required]
        public short? Soluong { get; set; }
       
        [DisplayName("Đơn giá")]
        [Required]
        public int? Dongia { get; set; }
        [DisplayName("Ảnh")]

        public string Img { get; set; }
        [StringLength(70, ErrorMessage = "Thông tin không được quá 70 ký tự")]
        [DisplayName("Thông tin")]
        [Required]
        public string Thongtin { get; set; }

        [DisplayName("Danh mục")]
        public virtual Danhmuc MadmNavigation { get; set; }
        public virtual ICollection<CtHoadon> CtHoadons { get; set; }
    }
}
