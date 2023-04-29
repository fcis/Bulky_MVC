using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
         _context = context;
        }
        public IActionResult Index()
        { 
            List<Category> categories = _context.Categories.ToList();

             return View(categories);
        }
        public IActionResult Create() 
        { 
        return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //Logic Validation in server side 
            //if (category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            if (ModelState.IsValid)
            {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int ? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category Edited Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int ? id)
        {
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();  
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction ("Index");
        }
    }
}
