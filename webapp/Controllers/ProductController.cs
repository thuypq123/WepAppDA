using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;
using System;

namespace WepApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly covid19Context _context;

        public ProductController()
        {
            _context = new covid19Context();
        }
        //public IActionResult Index(string search, int? page)
        //{
        //    var pageNumber = page ?? 1;
        //    ViewBag.Count = _context.Sanphams.Where(s => s.Tensp.Contains(search)).Count();
        //    ViewBag.Sanphams = _context.Sanphams.ToList().ToPagedList(pageNumber, 1);
        //    return View(_context.Sanphams.Where(x => x.Tensp.Contains(search) || search == null).ToList());

        //}

        public async Task<IActionResult> IndexAsync(int id,int page=0)
        {
            var id2 = id>0 ? id : -1;
            var sanpham = _context.Sanphams.ToList().Skip((page-1)*6).Take(6);
            if (id2 != -1)
            {
                sanpham = _context.Sanphams.Where(m => m.Madm == id2).ToList();
            }
            ViewBag.Count = 0;
            var n = (float)(_context.Sanphams.ToList().Count() / 6+1);
            //ViewBag.PageSize = Math.Round((float)n);
            ViewBag.PageSize = n;
            ViewBag.Page = page;
            ViewBag.DanhMuc = _context.Danhmucs.ToList();
            return View(sanpham);
        }
        
        public IActionResult Details(int id)
        {
            var sanpham = _context.Sanphams.First(x => x.Masp == id);
            ViewBag.DanhMuc = _context.Danhmucs.ToList();
            return View(sanpham);
        }
        public IActionResult Pagecarts()
        {
            return View();
        }

        public async Task<IActionResult> search(string searchPhrase)
        {
            ViewBag.Count = _context.Sanphams.Where(sp => sp.Tensp.Contains(searchPhrase)).Count();
            ViewBag.DanhMuc = _context.Danhmucs.ToList();
            return View("Index", await _context.Sanphams.Where(sp => sp.Tensp.Contains(searchPhrase)).ToListAsync());
        }
        public async Task<IActionResult> searchCat(string searchPhrase)
        {
            //ViewBag.Count = _context.Sanphams.Where(sp => sp.Tensp.Contains(searchPhrase)).Count();

            return View("Index", await _context.Danhmucs.Where(sp => sp.Tendm == searchPhrase).ToListAsync());
        } 
    }
}

