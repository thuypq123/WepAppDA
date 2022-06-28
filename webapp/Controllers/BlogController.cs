using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp.Controllers
{
    public class BlogController : Controller
    {
        private readonly covid19Context _context;

        public BlogController()
        {
            _context = new covid19Context();
        }
        public IActionResult Index()
        {
            var blog = _context.Blogs.ToList();
            return View(blog);
        }
        public IActionResult Details(int id)
        {
            var Blog = _context.Blogs.First(x => x.Mablog == id);
           
            return View(Blog);
        }
    }
}
