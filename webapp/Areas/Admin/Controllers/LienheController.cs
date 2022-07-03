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
    public class LienheController : Controller
    {
        private readonly covid19Context _context;

        public LienheController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Lienhe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lienhes.ToListAsync());
        }

        // GET: Admin/Lienhe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienhe = await _context.Lienhes
                .FirstOrDefaultAsync(m => m.Malh == id);
            if (lienhe == null)
            {
                return NotFound();
            }

            return View(lienhe);
        }

        // GET: Admin/Lienhe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Lienhe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Malh,Diachi,Sdt,Email,Facebook")] Lienhe lienhe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lienhe);
                await _context.SaveChangesAsync();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Đã thêm thất bại";

            }
            return View(lienhe);
        }

        // GET: Admin/Lienhe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienhe = await _context.Lienhes.FindAsync(id);
            if (lienhe == null)
            {
                return NotFound();
            }
            return View(lienhe);
        }

        // POST: Admin/Lienhe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Malh,Diachi,Sdt,Email,Facebook")] Lienhe lienhe)
        {
            if (id != lienhe.Malh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lienhe);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Đã sửa thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LienheExists(lienhe.Malh))
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
            return View(lienhe);
        }

        // GET: Admin/Lienhe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienhe = await _context.Lienhes
                .FirstOrDefaultAsync(m => m.Malh == id);
            if (lienhe == null)
            {
                return NotFound();
            }

            return View(lienhe);
        }

        // POST: Admin/Lienhe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lienhe = await _context.Lienhes.FindAsync(id);
            _context.Lienhes.Remove(lienhe);
            await _context.SaveChangesAsync();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool LienheExists(int id)
        {
            return _context.Lienhes.Any(e => e.Malh == id);
        }
    }
}
