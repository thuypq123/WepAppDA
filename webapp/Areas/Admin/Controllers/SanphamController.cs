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
    public class SanphamController : Controller
    {
        private readonly covid19Context _context;

        public SanphamController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Sanpham
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.Sanphams.Include(s => s.MadmNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/Sanpham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.MadmNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Admin/Sanpham/Create
        public IActionResult Create()
        {
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Madm");
            return View();
        }

        // POST: Admin/Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masp,Madm,Tensp,Soluong,Dongia,Img,Thongtin")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Madm", sanpham.Madm);
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Madm", sanpham.Madm);
            return View(sanpham);
        }

        // POST: Admin/Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masp,Madm,Tensp,Soluong,Dongia,Img,Thongtin")] Sanpham sanpham)
        {
            if (id != sanpham.Masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Masp))
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
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Madm", sanpham.Madm);
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.MadmNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Admin/Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanphams.FindAsync(id);
            _context.Sanphams.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanphams.Any(e => e.Masp == id);
        }
    }
}
