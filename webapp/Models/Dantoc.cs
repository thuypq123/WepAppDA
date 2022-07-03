using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Dantoc
    {
        public Dantoc()
        {
            Khachhangs = new HashSet<Khachhang>();
        }

        public int Madt { get; set; }
        [StringLength(20, ErrorMessage = "Dân tộc không được quá 20 ký tự")]
        [DisplayName("Dân tộc")]
        [Required]
        public string Tendt { get; set; }

        public virtual ICollection<Khachhang> Khachhangs { get; set; }
    }
}
