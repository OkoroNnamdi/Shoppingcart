using Microsoft.AspNetCore.Mvc;
using ShoppingChart.DataAccess;
using ShoppingChart.DataAccess.Repositories;

namespace ShoppingChart.web.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _unitofwork;
        public CategoryController( IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
            
        }
        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.categories = _unitofwork.category.GetAll();
            return View(categoryVM );
        }
        [HttpGet ]
        public IActionResult CreateUpdate(int?  id)
        {
            CategoryVM categoryVM = new CategoryVM();
           if (id == null  || id ==0) 
            { 
                return View(categoryVM);
            }
           else
            {
                categoryVM.category = _unitofwork.category.GetT (x=>x.Id == id);
                if (categoryVM.category == null )
                {
                    return NotFound();
                }
                else
                {
                    return View(categoryVM);
                }
            }
        }
        [HttpPost ]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.category .Id == 0)
                {
                    _unitofwork.category.Add (vm.category);
                    TempData["Sucess"] = "Category has been added";
                }
                else
                {
                    _unitofwork.category.Update (vm.category);
                    TempData["Sucess"] = "Category has been Updated";

                }
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet ]
        public IActionResult Delete(int? id)
        {
            
            var catgory = _unitofwork.category.GetT (x=>x.Id == id);
            if (catgory == null)
            {
                return NotFound ();
            }
            _unitofwork.category.Delete (catgory);
            _unitofwork.Save();
            return View(catgory);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData (int? id)
        {
            var category = _unitofwork.category .GetT (x=>x.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            
                _unitofwork.category.Delete(category);
                _unitofwork.Save();
                TempData["Sucess"] = "Category Deleted Sucessfully";
              
                return  RedirectToAction("Index");
        }
    }
}
