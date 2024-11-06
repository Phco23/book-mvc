using book_mvc.Models;
using book_mvc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book_mvc.Controllers
{
    public class SortByController : Controller
    {
        private readonly DataContext _dataContext;
        public SortByController(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();

            if (category == null) return RedirectToAction("Index");

            var productByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);

            return View("~/Views/Category/SortBy/Index.cshtml", await productByCategory.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
