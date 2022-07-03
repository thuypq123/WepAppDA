using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Madm { get; set; }
        [StringLength(30, ErrorMessage = "Danh mục không được quá 30 ký tự")]
        [DisplayName("Danh mục")]
        [Required]
        public string Tendm { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
