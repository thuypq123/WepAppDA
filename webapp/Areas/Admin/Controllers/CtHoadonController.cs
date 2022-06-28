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
    public class CtHoadonController : Controller
    {
        private readonly covid19Context _context;

        public CtHoadonController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/CtHoadon
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.CtHoadons.Include(c => c.MaspNavigation).Include(c => c.MdhdNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/CtHoadon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHoadon = await _context.CtHoadons
                .Include(c => c.MaspNavigation)
                .Include(c => c.MdhdNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (ctHoadon == null)
            {
                return NotFound();
            }

            return View(ctHoadon);
        }

        // GET: Admin/CtHoadon/Create
        public IActionResult Create()
        {
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp");
            ViewData["Mdhd"] = new SelectList(_context.Hoadons, "Mdhd", "Mdhd");
            return View();
        }

        // POST: Admin/CtHoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masp,Mdhd,Dongia,Soluong")] CtHoadon ctHoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctHoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", ctHoadon.Masp);
            ViewData["Mdhd"] = new SelectList(_context.Hoadons, "Mdhd", "Mdhd", ctHoadon.Mdhd);
            return View(ctHoadon);
        }

        // GET: Admin/CtHoadon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHoadon = await _context.CtHoadons.FindAsync(id);
            if (ctHoadon == null)
            {
                return NotFound();
            }
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", ctHoadon.Masp);
            ViewData["Mdhd"] = new SelectList(_context.Hoadons, "Mdhd", "Mdhd", ctHoadon.Mdhd);
            return View(ctHoadon);
        }

        // POST: Admin/CtHoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masp,Mdhd,Dongia,Soluong")] CtHoadon ctHoadon)
        {
            if (id != ctHoadon.Masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctHoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtHoadonExists(ctHoadon.Masp))
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
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", ctHoadon.Masp);
            ViewData["Mdhd"] = new SelectList(_context.Hoadons, "Mdhd", "Mdhd", ctHoadon.Mdhd);
            return View(ctHoadon);
        }

        // GET: Admin/CtHoadon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHoadon = await _context.CtHoadons
                .Include(c => c.MaspNavigation)
                .Include(c => c.MdhdNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (ctHoadon == null)
            {
                return NotFound();
            }

            return View(ctHoadon);
        }

        // POST: Admin/CtHoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctHoadon = await _context.CtHoadons.FindAsync(id);
            _context.CtHoadons.Remove(ctHoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtHoadonExists(int id)
        {
            return _context.CtHoadons.Any(e => e.Masp == id);
        }
    }
}
