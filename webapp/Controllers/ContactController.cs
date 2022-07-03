using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapp.Models;

namespace WepApp.Controllers
{
    public class ContactController : Controller
    {
        covid19Context _context = new covid19Context();
        public IActionResult Index()
        {
            var lienhe = _context.Lienhes.ToList();
            return View(lienhe);
        }
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FeedbackAsync(string Noidung, string Tinhtrang)
        {
            byte[] bytes = Encoding.Default.GetBytes(Noidung);
            Noidung = Encoding.UTF8.GetString(bytes);
            Gopy gopY = new Gopy()
            {
                Makh = 1,
                Noidung = Noidung
              
            };
            _context.Gopies.Add(gopY);
            await _context.SaveChangesAsync();
            return View("feedback");
        }
    }
}
