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
    public class QuoctichController : Controller
    {
        private readonly covid19Context _context;

        public QuoctichController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Quoctich
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quoctiches.ToListAsync());
        }

        // GET: Admin/Quoctich/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quoctich = await _context.Quoctiches
                .FirstOrDefaultAsync(m => m.Maqt == id);
            if (quoctich == null)
            {
                return NotFound();
            }

            return View(quoctich);
        }

        // GET: Admin/Quoctich/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Quoctich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maqt,Tenqt")] Quoctich quoctich)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quoctich);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quoctich);
        }

        // GET: Admin/Quoctich/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quoctich = await _context.Quoctiches.FindAsync(id);
            if (quoctich == null)
            {
                return NotFound();
            }
            return View(quoctich);
        }

        // POST: Admin/Quoctich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maqt,Tenqt")] Quoctich quoctich)
        {
            if (id != quoctich.Maqt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quoctich);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoctichExists(quoctich.Maqt))
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
            return View(quoctich);
        }

        // GET: Admin/Quoctich/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quoctich = await _context.Quoctiches
                .FirstOrDefaultAsync(m => m.Maqt == id);
            if (quoctich == null)
            {
                return NotFound();
            }

            return View(quoctich);
        }

        // POST: Admin/Quoctich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quoctich = await _context.Quoctiches.FindAsync(id);
            _context.Quoctiches.Remove(quoctich);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoctichExists(int id)
        {
            return _context.Quoctiches.Any(e => e.Maqt == id);
        }

        public async Task<IActionResult> Search(string search)
        {
            if (ModelState.IsValid && search != null)
            {
                return View("Index", await _context.Quoctiches.Where(qt => qt.Tenqt.Contains(search)).ToListAsync());
            }
            return RedirectToAction("Index", _context.Quoctiches.ToListAsync());
        }
    }
}
