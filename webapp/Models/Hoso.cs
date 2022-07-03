using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Hoso
    {
        public int Mahs { get; set; }
        public DateTime? Ngaylap { get; set; }
        [StringLength(50, ErrorMessage = "Khu vực không được quá 50 ký tự")]
        [DisplayName("Khu vực")]
        [Required]
        public string Khuvuc { get; set; }
        [DisplayName("Tình trạng")]
        public short? Tinhtrang { get; set; }
        public int Makh { get; set; }
        [DisplayName("Khách hàng")]
        public virtual Khachhang MakhNavigation { get; set; }
    }
}
