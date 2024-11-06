using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemAcademy.Business.Operations.Product;
using RemAcademy.Business.Operations.Product.Dtos;
using RemAcademy.WebApi.Filters;
using RemAcademy.WebApi.Models;

namespace RemAcademy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var addProductDto = new AddProductDto
            {
                CourseName = request.CourseName,
                ClassGrade = request.ClassGrade,
            };

            var result = await _productService.AddProduct(addProductDto);
            if (result.IsSucceed)
                return Ok();
            else
                return BadRequest(result.Message);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product is null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpPatch("{id}/courseName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeCourseName(int id, string changeBy)
        {
            var result = await _productService.ChangeCourseName(id, changeBy);

            if (!result.IsSucceed)
                return NotFound();
            else
                return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (!result.IsSucceed)
                return NotFound(result.Message);
            else
                return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [TimeControlerFilter]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            var updateProductDto = new UpdateProductDto
            {
                Id = id,
                CourseName = request.CourseName,
                ClassGrade = request.ClassGrade,
            };

            var result = await _productService.UpdateProduct(updateProductDto);

            if(!result.IsSucceed)
                return NotFound(result.Message);
            else
                return await GetProduct(id);
        }
    }
}
