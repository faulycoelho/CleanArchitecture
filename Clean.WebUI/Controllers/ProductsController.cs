using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.WebUI.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        readonly IProductService _productService;
        readonly ICategoryService _categoryService;
        readonly IWebHostEnvironment _environment;
        public ProductsController(
            IProductService productService,
            ICategoryService categoryService,
            IWebHostEnvironment environment)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var entities = await _productService.GetAllAsync();
            return View(entities);
        }

        private async Task fillViewBagCategory(int? selectedvalue = null)
            => ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", selectedvalue);

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            await fillViewBagCategory();
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            await fillViewBagCategory();
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            var productDTO = await _productService.GetAsync(id);
            if (productDTO == null)
                return NotFound();

            var categories = await _categoryService.GetAllAsync();
            await fillViewBagCategory(productDTO.CategoryId);
            return View(productDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            var ProductDTO = await _productService.GetAsync(id);
            if (ProductDTO == null)
                return NotFound();

            return View(ProductDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet()]
        public async Task<IActionResult> Details(int id)
        {
            var productDto = await _productService.GetAsync(id);
            if (productDto == null)
                return NotFound();

            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;
            return View(productDto);
        }
    }
}
