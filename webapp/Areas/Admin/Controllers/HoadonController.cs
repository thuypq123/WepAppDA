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
    public class HoadonController : Controller
    {
        private readonly covid19Context _context;

        public HoadonController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Hoadon
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.Hoadons.Include(h => h.MakhNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/Hoadon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .Include(h => h.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Mdhd == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: Admin/Hoadon/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh");
            return View();
        }

        // POST: Admin/Hoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mdhd,Makh,Ngaylap,Tongtien,Nguoinhan,Diachinhan,Sdtnhan,Tinhtranggiaohang,Tinhtrangthanhtoan")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", hoadon.Makh);
            return View(hoadon);
        }

        // GET: Admin/Hoadon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", hoadon.Makh);
            return View(hoadon);
        }

        // POST: Admin/Hoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mdhd,Makh,Ngaylap,Tongtien,Nguoinhan,Diachinhan,Sdtnhan,Tinhtranggiaohang,Tinhtrangthanhtoan")] Hoadon hoadon)
        {
            if (id != hoadon.Mdhd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.Mdhd))
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
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", hoadon.Makh);
            return View(hoadon);
        }

        // GET: Admin/Hoadon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .Include(h => h.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Mdhd == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: Admin/Hoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _context.Hoadons.FindAsync(id);
            _context.Hoadons.Remove(hoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoadonExists(int id)
        {
            return _context.Hoadons.Any(e => e.Mdhd == id);
        }
    }
}
