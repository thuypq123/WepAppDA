using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using webapp.Models;

namespace webapp.Controllers
{
    public class TokhaiController : Controller
    {
        private readonly covid19Context _context;
        public TokhaiController()
        {
            _context = new covid19Context();
        }

        // GET: TokhaiController
        public ActionResult Index()
        {
            var listTokhai = _context.Tokhais.ToList();
            return View(listTokhai);
        }

        // GET: TokhaiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TokhaiController/Create
        public ActionResult Create()
        {
            ViewBag.Diachi = _context.Lienhes.ToList();
            return View();
        }

        // POST: TokhaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var tokhai = new Tokhai();
                tokhai.Makh = 1;
                _context.Tokhais.Add(tokhai);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TokhaiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TokhaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TokhaiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TokhaiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
