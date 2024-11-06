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
        public async Task<IActionResult> Index(int Id)
        {
            if (Id == null) return RedirectToAction("Index");

            var productsById = _context.Products.Where(p => p.Id == Id).FirstOrDefault();
            return View(productsById);
        }
    }
}
