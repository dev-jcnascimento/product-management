using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductManagement.Domain.Arguments.Product;
using ProductManagement.Domain.Interface.IServices;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceProduct _serviceProduct;

        public ProductController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateProductRequest request)
        {
            if (request == null) return BadRequest(new { message = "Cadastro não pode ser vazio!" });

            var response = _serviceProduct.Create(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> ListAsync()
        {
            var response = _serviceProduct.List();
            return Ok(response);
        }

        [HttpGet]
        [Route("product_id")]
        public async Task<ActionResult> GetByIdAsyn([BindRequired, FromQuery] Guid id)
        {
            var response = _serviceProduct.GetById(id);

            if (response == null) return NotFound(new { message = "Produto não Encontrado!" });
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult> UpdateAsyn(UpdateProductRequest request)
        {
            var response = _serviceProduct.Update(request);

            if (response == null) return NotFound(new { message = "Produto não Encontrado!" });
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult> Delete([BindRequired, FromQuery] Guid id)
        {
            var user = _serviceProduct.Delete(id);

            if (user == null) return NotFound(new { message = "Id não Encontrado!" });
            return NoContent();
        }
    }
}
