using Bugeto_Test.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        
        private readonly IProductFacade _productFacade;
        public CategoriesController(IProductFacade productFacade) 
        {
            _productFacade = productFacade;

        }

        public IActionResult Index(long? ParentID) 
        {
          return View(_productFacade.GetCategoriesService.Execute(ParentID).Data);
        }

        
        [HttpGet]
        public IActionResult AddNewCategory(long? parentID) 
        {
         ViewBag.parentID = parentID;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(long? parentID, string Name) 
        {
            var result = _productFacade.AddNewCategoryService.Execute(parentID, Name);
            return Json(result);
        }








        public IActionResult Index()
        {
            return View();
        }
    }
}
