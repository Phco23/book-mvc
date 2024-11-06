using Microsoft.AspNetCore.Mvc;

namespace book_mvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
