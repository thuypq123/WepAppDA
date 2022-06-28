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
    public class TokhaiController : Controller
    {
        private readonly covid19Context _context;

        public TokhaiController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Tokhai
        public async Task<IActionResult> Index()
        {
            var covid19Context = _context.Tokhais.Include(t => t.MakhNavigation);
            return View(await covid19Context.ToListAsync());
        }

        // GET: Admin/Tokhai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tokhai = await _context.Tokhais
                .Include(t => t.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Matokhai == id);
            if (tokhai == null)
            {
                return NotFound();
            }

            return View(tokhai);
        }

        // GET: Admin/Tokhai/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh");
            return View();
        }

        // POST: Admin/Tokhai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matokhai,Dinhungdau,Trieuchung,Txnguoibenh,Txnguoinuocbenh,Nguoicobieuhien,Makh")] Tokhai tokhai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tokhai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", tokhai.Makh);
            return View(tokhai);
        }

        // GET: Admin/Tokhai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tokhai = await _context.Tokhais.FindAsync(id);
            if (tokhai == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", tokhai.Makh);
            return View(tokhai);
        }

        // POST: Admin/Tokhai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matokhai,Dinhungdau,Trieuchung,Txnguoibenh,Txnguoinuocbenh,Nguoicobieuhien,Makh")] Tokhai tokhai)
        {
            if (id != tokhai.Matokhai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tokhai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TokhaiExists(tokhai.Matokhai))
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
            ViewData["Makh"] = new SelectList(_context.Khachhangs, "Makh", "Makh", tokhai.Makh);
            return View(tokhai);
        }

        // GET: Admin/Tokhai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tokhai = await _context.Tokhais
                .Include(t => t.MakhNavigation)
                .FirstOrDefaultAsync(m => m.Matokhai == id);
            if (tokhai == null)
            {
                return NotFound();
            }

            return View(tokhai);
        }

        // POST: Admin/Tokhai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tokhai = await _context.Tokhais.FindAsync(id);
            _context.Tokhais.Remove(tokhai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TokhaiExists(int id)
        {
            return _context.Tokhais.Any(e => e.Matokhai == id);
        }
    }
}
