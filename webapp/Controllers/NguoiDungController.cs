using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp.Controllers
{
    public class NguoiDungController : Controller
    {
        covid19Context context = new covid19Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(IFormCollection collection, Khachhang kh)
        {
            string hoten = collection["hoten"];
            string tendn = collection["username"];
            string matkhau = collection["pass"];
            string matkhaunhaplai = collection["repeatpass"];
            string diachi = collection["diachi"];
            string email = collection["email"];
            string sdt = collection["sdt"];
            string ngaysinh = String.Format("{0:MM/dd/YYYY}", collection["ngaysinh"]);
            if (matkhau != matkhaunhaplai)
            {
                ViewData["Loi7"] = "Hai mật khẩu phải giống nhau";
            }
            else
            {
                kh.Tenkh = hoten;
                kh.Tk = tendn;
                kh.Mk = matkhau;
                kh.Diachi = diachi;
                kh.Sdt = sdt;
                //kh.email = email;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                context.Khachhangs.Add(kh);
                context.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }

        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(IFormCollection collection)
        {
            string tendn = collection["username"];
            string matkhau = collection["pass"];
            
            Khachhang kh = context.Khachhangs.SingleOrDefault(p => p.Tk == tendn && p.Mk == matkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                SessionHelpers.SetObjAsJson(HttpContext.Session,"TaiKhoan", kh);
            }
            else
                ViewBag.ThongBao = "Đăng nhập thất bại";

            return RedirectToAction("Index","Home");
        }

    }
}
