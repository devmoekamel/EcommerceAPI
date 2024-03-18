using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult GetCategories()
        {
          var categories = _categoryService.GetCategories();    
            return Ok(categories);
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);
            var result = _categoryService.AddCategory(category);
            if(result is not true) return BadRequest("Somthing went wrong");
            return Ok("Category Created");
        }

        // GET: api/Category/5/Products
        [HttpGet("{id}/Products")]
        public ActionResult GetProductsInCategory(int id)
        {
          var Products =  _categoryService.GetProductsInCategory(id);
            if (Products is null)  return BadRequest("Somthing went wrong");
            return Ok(Products);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
         var result  = _categoryService.RemoveCategory(id);

            if (result is not true) return BadRequest("Somthing went wrong");
            return Ok("Category Removed");
        }
    }
}
