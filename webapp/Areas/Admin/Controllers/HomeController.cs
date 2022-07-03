using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models;

namespace webapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (SessionHelpers.GetObjFromJson<Tkadmin>(HttpContext.Session, "Tkadmin") == null)
            {
                return RedirectToAction("Login", "Tkadmin");
            }
            else
            {
                return View();
            }
        }

            
    }
}
