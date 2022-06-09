using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Services.InterfaceServices;

namespace WebPhone.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = categoryService.GetCategories();
            return View(list);
        }

     


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryDTO());
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO category)
        {
            if (ModelState.IsValid == true)
            {
                categoryService.Insert(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
          var list=  categoryService.GetCategoryById(Id);
            return View(list);
        }

        [HttpPost]
        public IActionResult Edit(CategoryDTO category)
        {
            if (ModelState.IsValid == false)
            {
                return View(category);
             }
            categoryService.Update(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            categoryService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }


    }
}
