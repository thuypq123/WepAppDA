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
    public class HosoController : Controller
    {
        private readonly covid19Context _context;

        public HosoController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Hoso
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.Hosos.Include(h => h.MakhNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/Hoso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoso = await _context.Hosos
                .Include(h => h.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Mahs == id);
            if (hoso == null)
            {
                return NotFound();
            }

            return View(hoso);
        }

        // GET: Admin/Hoso/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh");
            return View();
        }

        // POST: Admin/Hoso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahs,Ngaylap,Khuvuc,Tinhtrang,Makh")] Hoso hoso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", hoso.Makh);
            return View(hoso);
        }

        // GET: Admin/Hoso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoso = await _context.Hosos.FindAsync(id);
            if (hoso == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", hoso.Makh);
            return View(hoso);
        }

        // POST: Admin/Hoso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahs,Ngaylap,Khuvuc,Tinhtrang,Makh")] Hoso hoso)
        {
            if (id != hoso.Mahs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HosoExists(hoso.Mahs))
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
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", hoso.Makh);
            return View(hoso);
        }

        // GET: Admin/Hoso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoso = await _context.Hosos
                .Include(h => h.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Mahs == id);
            if (hoso == null)
            {
                return NotFound();
            }

            return View(hoso);
        }

        // POST: Admin/Hoso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoso = await _context.Hosos.FindAsync(id);
            _context.Hosos.Remove(hoso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HosoExists(int id)
        {
            return _context.Hosos.Any(e => e.Mahs == id);
        }
    }
}
