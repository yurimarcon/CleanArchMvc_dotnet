using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if(categories == null)
                return NotFound("Categories not found");
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            if(category == null)
                return NotFound("Category not found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CategoryDTO category)
        {
            if(category == null)
                return BadRequest("Invalid Data");

            await _categoryService.Add(category);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Put(int id, CategoryDTO category)
        {
            if(id != category.Id)
                return BadRequest("Invalid id");
            if(category == null)
                return BadRequest("Invalid Data");

            var categoryEntity = await _categoryService.GetById(id);
            if(categoryEntity == null)
                return NotFound("Category not found");

            await _categoryService.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if(category == null)
                return NotFound("Category not found");

            await _categoryService.Delete(id);
            return Ok(category);
        }
    }
}