using System;
using System.Collections.Generic;

#nullable disable

namespace webapp.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Blogs = new HashSet<Blog>();
        }

        public string Tk { get; set; }
        public string Mk { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
