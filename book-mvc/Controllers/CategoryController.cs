using book_mvc.Models;
using book_mvc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book_mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        public CategoryController(DataContext context)
        {
            _dataContext = context;
        }
        public  IActionResult Index()
        {


            var products = _dataContext.Products.ToList();

            return View(products);
        }
    }
}
