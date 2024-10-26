using book_mvc.Repository;
using Microsoft.AspNetCore.Mvc;

namespace book_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
