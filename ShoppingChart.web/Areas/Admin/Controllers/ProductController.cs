using Microsoft.AspNetCore.Mvc;
using ShoppingChart.DataAccess.Repositories;

namespace ShoppingChart.web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitofWork _unitofwork;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllProduct()
        {
            var products = _unitofwork.category.GetAll(includeProperties: "category");
            return Json(new { data = products });

        }
    }
}
