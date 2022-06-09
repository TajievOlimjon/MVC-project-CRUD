using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Services.InterfaceServices;

namespace WebPhone.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = productService.GetProducts();
            return View(list);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var list = productService.GetProductCategories();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = categoryService.GetCategories();
            
            ViewBag.Categories = categories;
            return View(new ProductDTO());
        }

        [HttpPost]
        public IActionResult Create(ProductDTO product)
        {
            if (ModelState.IsValid == true)
            {
                productService.Insert(product);
                return RedirectToAction(nameof(GetAll));

            }                     
            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;
            return View(product);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var listofById = productService.GetProductById(id);
            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;
            return View(listofById);
        }

        [HttpPost]
        public IActionResult Edit(ProductDTO product )
        {
            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;

            if (ModelState.IsValid == false)
            {
                 
                return View(product);

            }
             
            productService.Update(product);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
       public IActionResult Delete(int Id)
        {
            var d = productService.Delete(Id);
            return RedirectToAction(nameof(GetAll));
        }

       


    }
}
