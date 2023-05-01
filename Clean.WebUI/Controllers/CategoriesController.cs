using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await this._categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDto = await _categoryService.GetAsync(id);
            if (categoryDto == null)
                return NotFound();

            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }



        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDto = await _categoryService.GetAsync(id);
            if (categoryDto == null)
                return NotFound();

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet()]
        public async Task<IActionResult> Details(int id)
        {
            var categoryDto = await _categoryService.GetAsync(id);
            if (categoryDto == null)
                return NotFound();

            return View(categoryDto);
        }         
    }
}
