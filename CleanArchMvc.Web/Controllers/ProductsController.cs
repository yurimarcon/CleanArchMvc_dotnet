using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.AspNetCore.Hosting;

namespace CleanArchMvc.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _enviroment;
        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment enviroment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _enviroment = enviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id == null) return NotFound();
            
            var product = await _productService.GetById(id);
            if(product == null) return NotFound();

            var categories = await _categoryService.GetCategories();
            if(categories == null) return NotFound();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product)
        {
            await _productService.Update(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == null) return NotFound();

            var productDTO = await _productService.GetById(id);

            if(productDTO == null) return NotFound();

            return View(productDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _productService.Delete(id);
                }
                catch(Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int id)
        {
            if(id == null) return NotFound();

            var productDto = await _productService.GetById(id);
            if(productDto == null) return NotFound();

            var wwwroot = _enviroment.WebRootPath;
            var images = Path.Combine(wwwroot, "images/" + productDto.Image);
            var exists = System.IO.File.Exists(images);
            ViewBag.ImageExists = exists;

            return View(productDto);
        }
    }
}