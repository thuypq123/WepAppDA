using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace webapp.Controllers
{
    public class GioHangController : Controller
    {

        covid19Context context = new covid19Context();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = SessionHelpers.GetObjFromJson<List<GioHang>>(HttpContext.Session, "GioHang");
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                SessionHelpers.SetObjAsJson(HttpContext.Session, "GioHang", lstGioHang);
            }
            return lstGioHang;
        }

        public IActionResult ThemGioHang(int masp, string strURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(sp => sp.MaSP == masp);
            if (sanpham == null)
            {
                sanpham = new GioHang(masp);
                lstGioHang.Add(sanpham);
                SessionHelpers.SetObjAsJson(HttpContext.Session, "GioHang", lstGioHang);
                return Redirect(strURL);
            }
            else
            {
                sanpham.SoLuong++;
                SessionHelpers.SetObjAsJson(HttpContext.Session, "GioHang", lstGioHang);
                return Redirect(strURL);
            }
        }

        public IActionResult XoaGioHang(int masp)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(sp => sp.MaSP == masp);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(sp => sp.MaSP == masp);
                SessionHelpers.SetObjAsJson(HttpContext.Session, "GioHang", lstGioHang);
                return RedirectToAction("GioHang");
            }
            else if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("GioHang");
        }


        public IActionResult CapNhat(int masp, IFormCollection collection)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.MaSP == masp);
            if (sanpham != null)
            {
                sanpham.SoLuong = int.Parse(collection["soluong"].ToString());
            }
            SessionHelpers.SetObjAsJson(HttpContext.Session, "GioHang", lstGioHang);
            return RedirectToAction("GioHang");
        }

        public IActionResult XoaTatCa()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            HttpContext.Session.Remove("GioHang");
            return RedirectToAction("Index", "Product");
        }

        public IActionResult DatHang()
        {
            if(HttpContext.Session.GetString("TaiKhoan") == null || HttpContext.Session.GetString("TaiKhoan") == "")
            {
               return RedirectToAction("DangNhap", "NguoiDung");
            }
            if(SessionHelpers.GetObjFromJson<List<GioHang>>(HttpContext.Session,"GioHang") == null)
            {
                return RedirectToAction("Index", "Product");
            }

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();

            return View();
        }

        [HttpPost]
        public IActionResult DatHang(IFormCollection collection,string paymentmethod)
        {
            Hoadon hd = new Hoadon();
            Khachhang kh = SessionHelpers.GetObjFromJson<Khachhang>(HttpContext.Session,"TaiKhoan");
            List<GioHang> lstGioHang = LayGioHang();
            hd.Makh = kh.Makh;
            hd.Ngaylap = DateTime.Now;
            hd.Tongtien = TongTien();
            hd.Nguoinhan = collection["tenkh"];
            hd.Diachinhan = collection["diachi"];
            hd.Sdtnhan = collection["sdt"];
            hd.Tinhtranggiaohang = false;
            hd.Tinhtrangthanhtoan = false;
            context.Hoadons.Add(hd);
            context.SaveChanges();
            foreach(var item in lstGioHang)
            {
                CtHoadon ct = new CtHoadon();
                ct.Masp = item.MaSP;
                ct.Mdhd = hd.Mdhd;
                ct.Dongia = item.DonGia;
                ct.Soluong = (short)item.SoLuong;
                context.CtHoadons.Add(ct);
            }
            context.SaveChanges();
            SessionHelpers.SetObjAsJson(HttpContext.Session, "GioHang", null);
            if (paymentmethod == "CASH")
            {
                return RedirectToAction("XacNhanDonHang", "GioHang");
            }
            else
            {
                return RedirectToAction("XacNhanDonHang", "GioHang");
            }
            
        }

        public IActionResult XacNhanDonHang()
        {
            return View();
        }

        private int TongSoLuong()
        {
            int TongSoLuong = 0;
            List<GioHang> lstGioHang = SessionHelpers.GetObjFromJson<List<GioHang>>(HttpContext.Session, "GioHang");
            if (lstGioHang != null)
            {
                TongSoLuong = lstGioHang.Sum(sp => sp.SoLuong);
            }
            return TongSoLuong;
        }

        private int? TongTien()
        {
            int? tongtien = 0;
            List<GioHang> lstGioHang = SessionHelpers.GetObjFromJson<List<GioHang>>(HttpContext.Session, "GioHang");
            if (lstGioHang != null)
            {
                tongtien = lstGioHang.Sum(sp => sp.ThanhTien);
            }
            return tongtien;
        }

        public IActionResult GioHang() {
            List<GioHang> lstGioHang = LayGioHang();
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index","Product");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
    }
}
