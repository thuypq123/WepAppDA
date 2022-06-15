using Microsoft.AspNetCore.Mvc;

namespace WepApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
