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
        public async Task<IActionResult> Index()
        {
            var list = await productService.GetProducts();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await productService.GetProductCategories();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories =  categoryService.GetCategories();
            
            ViewBag.Categories = categories;
            return  View(new ProductDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid == true)
            {
               await productService.Insert(product);
                return RedirectToAction(nameof(GetAll));

            }                     
            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var listofById =await  productService.GetProductById(id);
            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;
            return View(listofById);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product )
        {
            var categories =  categoryService.GetCategories();
            ViewBag.Categories = categories;

            if (ModelState.IsValid == false)
            {                 
                return  View(product);
            }
             
            await productService.Update(product);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
       public async Task<IActionResult> Delete(int Id)
        {
            var d = await productService.Delete(Id);
            return   RedirectToAction(nameof(GetAll));
        }

       


    }
}
