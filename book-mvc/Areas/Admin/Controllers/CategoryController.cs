using book_mvc.Models;
using book_mvc.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Categories.OrderByDescending(c => c.Id).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel category)
        {

            if (ModelState.IsValid)
            {
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Category already have is database");
                    return View(category);
                }

                _dataContext.Add(category);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Add category ok !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Model is error";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);

            }
        }

        public async Task<IActionResult> Edit(int Id)
        {
            CategoryModel category = await _dataContext.Categories.FindAsync(Id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            var existed_category = await _dataContext.Categories.FindAsync(category.Id);

            if (ModelState.IsValid)
            {
                var slugExists = await _dataContext.Categories.AnyAsync(c => c.Slug == category.Slug && c.Id != category.Id);
                if (slugExists)
                {
                    ModelState.AddModelError("", "Category already exists in the database");
                    return View(category);
                }


                // Update other properties
                existed_category.Name = category.Name;
                existed_category.Description = category.Description;
                existed_category.Slug = category.Slug;

                _dataContext.Update(existed_category);

                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Model is invalid";
            return View(category);
        }


        public async Task<IActionResult> Delete(int Id)
        {
            CategoryModel category = await _dataContext.Categories.FindAsync(Id);

            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
            TempData["error"] = "Category have been removed";
            return RedirectToAction("Index");
        }
    }
}
