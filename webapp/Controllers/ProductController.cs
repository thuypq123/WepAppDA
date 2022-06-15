using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;



namespace WepApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly covid19Context _context;

        public ProductController()
        {
            _context = new covid19Context();
        }
        public ActionResult Index(string search, int? page)
        {
            var pageNumber = page ?? 1;
            ViewBag.Count = _context.Sanphams.Where(s => s.Tensp.Contains(search)).Count();
            ViewBag.Sanphams = _context.Sanphams.ToList().ToPagedList(pageNumber, 1);
            return View(_context.Sanphams.Where(x => x.Tensp.Contains(search) || search == null).ToList());

        }
        //public async Task<IActionResult> IndexAsync(int page=1)
        //{
        //    var q = _context.Sanphams.AsNoTracking().OrderBy(s => s.Dongia);
        //    var m = await PagingList.CreateAsync(q, 6, page);
        //    var sanpham = _context.Sanphams.ToList();
        //    //var danhmuc = _context.Danhmucs.ToList();
        //    //var newlist = new List<ExpandoObject>();
        //    //foreach (var item in sanpham)
        //    //{
        //    //    foreach (var item2 in danhmuc)
        //    //    {
        //    //        if(item.Madm == item2.Madm)
        //    //        {
        //    //            dynamic newobj = new ExpandoObject();
        //    //            newobj.Tensp = item.Tensp;
        //    //            newobj.Masp = item.Masp;
        //    //            newobj.Soluong = item.Soluong;
        //    //            newobj.Thongtin = item.Thongtin;
        //    //            newobj.MadmNavigation = item.MadmNavigation;
        //    //            newobj.Img = item.Img;
        //    //            newobj.Dongia = item.Dongia;
        //    //            newobj.Tendm = item2.Tendm;
        //    //            newlist.Add(newobj);
        //    //        }
        //    //    }
        //    //}
        //    //jaksdhajhdajkhdak
        //    ViewBag.Count = _context.Sanphams.Count();
        //    return View(m);
        //}
        public IActionResult Details(int id)
        {
            var sanpham = _context.Sanphams.First(x => x.Masp == id);
            return View(sanpham);
        }
        public IActionResult Pagecarts()
        {
            return View();
        }

        //    public async Task<IActionResult> search(string searchPhrase)
        //    {
        //        ViewBag.Count = _context.Sanphams.Where(sp => sp.Tensp.Contains(searchPhrase)).Count();
        //        return View("Index", await _context.Sanphams.Where(sp => sp.Tensp.Contains(searchPhrase)).ToListAsync());
        //    }
        //}
    }
}
