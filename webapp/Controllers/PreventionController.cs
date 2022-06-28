using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Controllers
{
    public class PreventionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
