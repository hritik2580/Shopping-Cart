using Microsoft.AspNetCore.Mvc;
using MyAppDataAccess;
using MyAppDataAccess.Infrastructure.IRepository;
using MyAppModels;

namespace Shopping.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;


        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //ienumerable does not return null
            IEnumerable<Category> category = _unitOfWork.CategoryRepository.GetAll();
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
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                //TempData["success"] = "Category created";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //EDIT

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            Category categories = new Category();
            if (id == null || id == 0)
            {
                return View(categories);
            }
            else
            {
                var category = _unitOfWork.CategoryRepository.GetT(x => x.ID == id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(category);
                }
            
                     
            }



           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//cross side scripting attack is prevented by it(inspect copy form wont  validate)
        public IActionResult CreateUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
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

            var category = _unitOfWork.CategoryRepository.GetT(x => x.ID == id);
            if (category == null)
            {
                return NotFound();
            }


            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]//cross side scripting attack is prevented by it(inspect copy form wont  validate)
        public IActionResult DeleteCategory(int? id)
        {

            var category = _unitOfWork.CategoryRepository.GetT(x => x.ID == id);
            _unitOfWork.CategoryRepository.Delete(category);
            TempData["success"] = "Category Deleted";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }




    }
}
