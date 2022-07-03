using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachhangController : Controller
    {
        private readonly covid19Context _context;

        public KhachhangController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Khachhang
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.Khachhangs.Include(k => k.MadtNavigation).Include(k => k.MaqtNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/Khachhang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.MadtNavigation)
                .Include(k => k.MaqtNavigation)
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Admin/Khachhang/Create
        public IActionResult Create()
        {
            ViewData["Madt"] = new SelectList(_context.Dantocs, "Madt", "Tendt");
            ViewData["Maqt"] = new SelectList(_context.Quoctiches, "Maqt", "Tenqt");
            return View();
        }

        // POST: Admin/Khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makh,Tenkh,Sdt,Cmnd,Diachi,Email,Anhdaidien,Ngaysinh,Tk,Mk,Gioitinh,Maqt,Madt")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Đã thêm thất bại";

            }
            ViewData["Madt"] = new SelectList(_context.Dantocs, "Madt", "Madt", khachhang.Madt);
            ViewData["Maqt"] = new SelectList(_context.Quoctiches, "Maqt", "Maqt", khachhang.Maqt);
            return View(khachhang);
        }

        // GET: Admin/Khachhang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["Madt"] = new SelectList(_context.Dantocs, "Madt", "Tendt", khachhang.Madt);
            ViewData["Maqt"] = new SelectList(_context.Quoctiches, "Maqt", "Tenqt", khachhang.Maqt);
            return View(khachhang);
        }

        // POST: Admin/Khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Makh,Tenkh,Sdt,Cmnd,Diachi,Email,Anhdaidien,Ngaysinh,Tk,Mk,Gioitinh,Maqt,Madt")] Khachhang khachhang)
        {
            if (id != khachhang.Makh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    TempData["success"] = "Đã sửa thành công";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.Makh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Madt"] = new SelectList(_context.Dantocs, "Madt", "Madt", khachhang.Madt);
            ViewData["Maqt"] = new SelectList(_context.Quoctiches, "Maqt", "Maqt", khachhang.Maqt);
            return View(khachhang);
        }

        // GET: Admin/Khachhang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.MadtNavigation)
                .Include(k => k.MaqtNavigation)
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Admin/Khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhangs.Any(e => e.Makh == id);
        }

        public async Task<IActionResult> Search(string search)
        {
            var covid19Context = _context.Khachhangs.Include(k => k.MadtNavigation).Include(k => k.MaqtNavigation);

            if (ModelState.IsValid && search != null)
            {
                return View("Index", await covid19Context.Where(kh => kh.Tenkh.Contains(search)).ToListAsync());       
            }
            return RedirectToAction("Index", await _context.Khachhangs.ToListAsync());
        }
    }
}
