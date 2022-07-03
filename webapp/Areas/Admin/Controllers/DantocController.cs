using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DantocController : Controller
    {
        private readonly covid19Context _context;

        public DantocController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Dantoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dantocs.ToListAsync());
        }

        // GET: Admin/Dantoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantocs
                .FirstOrDefaultAsync(m => m.Madt == id);
            if (dantoc == null)
            {
                return NotFound();
            }

            return View(dantoc);
        }


        // GET: Admin/Dantoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Dantoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madt,Tendt")] Dantoc dantoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dantoc);
                await _context.SaveChangesAsync();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Đã thêm thất bại";
             
            }
            return View(dantoc);
        }

        // GET: Admin/Dantoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantocs.FindAsync(id);
            if (dantoc == null)
            {
                return NotFound();
            }
            return View(dantoc);
        }

        // POST: Admin/Dantoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madt,Tendt")] Dantoc dantoc)
        {
            if (id != dantoc.Madt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dantoc);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Đã sửa thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DantocExists(dantoc.Madt))
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
            return View(dantoc);
        }

        // GET: Admin/Dantoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dantoc = await _context.Dantocs
                .FirstOrDefaultAsync(m => m.Madt == id);
            if (dantoc == null)
            {
                return NotFound();
            }

            return View(dantoc);
        }

        // POST: Admin/Dantoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dantoc = await _context.Dantocs.FindAsync(id);
            _context.Dantocs.Remove(dantoc);
            await _context.SaveChangesAsync();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool DantocExists(int id)
        {
            return _context.Dantocs.Any(e => e.Madt == id);
        }

        public async Task<IActionResult> Search(string search)
        {
            if (ModelState.IsValid && search != null)
            {
                return View("Index", await _context.Dantocs.Where(dt => dt.Tendt.Contains(search)).ToListAsync());
            }
            return RedirectToAction("Index", await _context.Dantocs.ToArrayAsync());
        }
    }
}
