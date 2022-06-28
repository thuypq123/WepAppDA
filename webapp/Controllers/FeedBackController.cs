using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepApp.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBackController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FeedBackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeedBackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedBackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: FeedBackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeedBackController/Edit/5
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

        // GET: FeedBackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeedBackController/Delete/5
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
