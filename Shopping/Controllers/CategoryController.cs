using Microsoft.AspNetCore.Mvc;
using MyAppDataAccess;
using MyAppModels;

namespace Shopping.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ienumerable does not return null
            IEnumerable<Category> category = _context.Categories;
            return View(category);
        }
      
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//cross side scripting attack is prevented by it(inspect copy form wont  validate)
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                //TempData["success"] = "Category created";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //EDIT

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
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
        [HttpPost]
        [ValidateAntiForgeryToken]//cross side scripting attack is prevented by it(inspect copy form wont  validate)
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category Edited";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
       //Delete
        [HttpGet]
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
        [ValidateAntiForgeryToken]//cross side scripting attack is prevented by it(inspect copy form wont  validate)
        public IActionResult DeleteCategory (int? id)
        {
              
            var category=_context.Categories.Find(id);
            _context.Categories.Remove(category);
            TempData["success"] = "Category Deleted";
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
