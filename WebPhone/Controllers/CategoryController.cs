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
        public async Task<IActionResult> Index()
        {
            var list = await categoryService.GetCategories();
            return View(list);
        }

     


        [HttpGet]
        public IActionResult Create()
        {
            return  View(new CategoryDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid == true)
            {
                 await categoryService.Insert(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
          var list= await  categoryService.GetCategoryById(Id);
            return View(list);
        }

        [HttpPost]
        public async  Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid == false)
            {
                return View(category);
             }
             await categoryService.Update(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await categoryService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }


    }
}
