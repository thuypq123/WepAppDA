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
    public class GopyController : Controller
    {
        private readonly covid19Context _context;

        public GopyController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Gopy
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.Gopies.Include(g => g.MakhNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/Gopy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gopy = await _context.Gopies
                .Include(g => g.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Magy == id);
            if (gopy == null)
            {
                return NotFound();
            }

            return View(gopy);
        }

        // GET: Admin/Gopy/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh");
            return View();
        }

        // POST: Admin/Gopy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Magy,Noidung,Tinhtrang,Makh")] Gopy gopy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gopy);
                await _context.SaveChangesAsync();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Đã thêm thất bại";

            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", gopy.Makh);
            return View(gopy);
        }

        // GET: Admin/Gopy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gopy = await _context.Gopies.FindAsync(id);
            if (gopy == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", gopy.Makh);
            return View(gopy);
        }

        // POST: Admin/Gopy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Magy,Noidung,Tinhtrang,Makh")] Gopy gopy)
        {
            if (id != gopy.Magy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gopy);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Đã sửa thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GopyExists(gopy.Magy))
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
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", gopy.Makh);
            return View(gopy);
        }

        // GET: Admin/Gopy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gopy = await _context.Gopies
                .Include(g => g.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Magy == id);
            if (gopy == null)
            {
                return NotFound();
            }

            return View(gopy);
        }

        // POST: Admin/Gopy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gopy = await _context.Gopies.FindAsync(id);
            _context.Gopies.Remove(gopy);
            await _context.SaveChangesAsync();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool GopyExists(int id)
        {
            return _context.Gopies.Any(e => e.Magy == id);
        }
    }
}
