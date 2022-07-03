using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webapp.Models
{
    public partial class Quoctich
    {
        public Quoctich()
        {
            Khachhangs = new HashSet<Khachhang>();
        }

        public int Maqt { get; set; }
        [StringLength(20, ErrorMessage = "Quốc tịch không được quá 20 ký tự")]
        [DisplayName("Quốc tịch")]
        [Required]
        public string Tenqt { get; set; }

        public virtual ICollection<Khachhang> Khachhangs { get; set; }
    }
}
