using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TkadminController : Controller
    {
        private readonly covid19Context _context;

        public TkadminController(covid19Context context)
        {
            _context = context;
        }

        // GET: Admin/Tkadmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tkadmins.ToListAsync());
        }

        // GET: Admin/Tkadmin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tkadmin = await _context.Tkadmins
                .FirstOrDefaultAsync(m => m.Tk == id);
            if (tkadmin == null)
            {
                return NotFound();
            }

            return View(tkadmin);
        }

        // GET: Admin/Tkadmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tkadmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tk,Mk,Hoten,Email")] Tkadmin tkadmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tkadmin);
                await _context.SaveChangesAsync();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Đã thêm thất bại";

            }
            return View(tkadmin);
        }

        // GET: Admin/Tkadmin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tkadmin = await _context.Tkadmins.FindAsync(id);
            if (tkadmin == null)
            {
                return NotFound();
            }
            return View(tkadmin);
        }

        // POST: Admin/Tkadmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Tk,Mk,Hoten,Email")] Tkadmin tkadmin)
        {
            if (id != tkadmin.Tk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tkadmin);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Đã sửa thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TkadminExists(tkadmin.Tk))
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
            return View(tkadmin);
        }

        // GET: Admin/Tkadmin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tkadmin = await _context.Tkadmins
                .FirstOrDefaultAsync(m => m.Tk == id);
            if (tkadmin == null)
            {
                return NotFound();
            }

            return View(tkadmin);
        }

        // POST: Admin/Tkadmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tkadmin = await _context.Tkadmins.FindAsync(id);
            _context.Tkadmins.Remove(tkadmin);
            await _context.SaveChangesAsync();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool TkadminExists(string id)
        {
            return _context.Tkadmins.Any(e => e.Tk == id);
        }

        public async Task<IActionResult> Search(string search)
        {
            if (ModelState.IsValid && search != null)
            {
                return View("Index", await _context.Tkadmins.Where(tk => tk.Tk.Contains(search)).ToListAsync());
            }    
            return RedirectToAction("Index", await _context.Tkadmins.ToListAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection collection)
        {
            string tk = collection["username"];
            string mk = collection["pass"];
            Tkadmin tkadmin = _context.Tkadmins.SingleOrDefault(t => t.Tk == tk && t.Mk == mk);
            if (tkadmin != null)
            {
                SessionHelpers.SetObjAsJson(HttpContext.Session, "Tkadmin", tkadmin);
                TempData["success"] = "Đăng nhập thành công";  
            }
            else
            {
                TempData["error"] = "Đăng nhập thất bại";
            }
            return RedirectToAction("Index", "Home");
        }

     

    }
}
