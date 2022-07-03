using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            CtHoadons = new HashSet<CtHoadon>();
        }

        public int Mdhd { get; set; }
        public int Makh { get; set; }

        public DateTime? Ngaylap { get; set; }
        [DisplayName("Tổng tiền")]
        [Required]
        public decimal? Tongtien { get; set; }
        [DisplayName("Tình trạng giao hàng")]
        public bool? Tinhtranggiaohang { get; set; }
        [DisplayName("Tình trạng thanh toán")]
        public bool? Tinhtrangthanhtoan { get; set; }

        [StringLength(30, ErrorMessage = "Tên người nhận không được quá 50 ký tự")]
        [DisplayName("Người nhận")]
        [Required]
        public string Nguoinhan { get; set; }
        [StringLength(50, ErrorMessage = "Địa chỉ nhận không được quá 50 ký tự")]
        [DisplayName("Địa chỉ nhận")]
        [Required]
        public string Diachinhan { get; set; }
        [StringLength(11, ErrorMessage = "Số điện thoại nhận không được quá 11 ký tự")]
        [DisplayName("Số điện thoại nhận")]
        [Required]
        public string Sdtnhan { get; set; }
        [DisplayName("Khách hàng")]
        public virtual Khachhang MakhNavigation { get; set; }
        public virtual ICollection<CtHoadon> CtHoadons { get; set; }
    }
}
