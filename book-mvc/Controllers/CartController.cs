using Microsoft.AspNetCore.Mvc;

namespace book_mvc.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
