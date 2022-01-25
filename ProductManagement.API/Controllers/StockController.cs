using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Arguments.Stock;
using ProductManagement.Domain.Interface.IServices;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("v1/stock")]
    public class StockController : ControllerBase
    {
        private readonly IServiceStock _serviceStock;

        public StockController(IServiceStock serviceStock)
        {
            _serviceStock = serviceStock;
        }
        [HttpPost]
        [Route("entrada")]
        public ActionResult InStock(CreateStockRequest request)
        {
            if (request == null || request.Value <= 0)
                return BadRequest(new { message = "Id's não podem ser vazio! e Valor não pode ser 0." });

            var response = _serviceStock.InStock(request);

            if (response == null)
            {
                return NotFound(new { message = "Id's não encontrados!" });
            }
           

            return Ok(response);
        }
        [HttpPost]
        [Route("saida")]
        public async Task<ActionResult> OutStock(CreateStockRequest request)
        {
            if (request == null || request.Value <= 0)
                return BadRequest(new { message = "Id's não podem ser vazio! e Valor não pode ser 0." });

            var response = _serviceStock.OutStock(request);

            if (response == null)
            {
                return NotFound(new { message = "Id's não encontrados!" });
            }
            if (response.Value == 0)
            {
                return BadRequest(new { message = "Estoque não pode ficar negativo" });
            }
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var stock = _serviceStock.Delete(id);

            if (stock == null)
                return NotFound(new { message = "Id não Encontrado!" });

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsyn(Guid id)
        {
            var response = _serviceStock.GetById(id);

            if (response == null)
                return NotFound(new { message = "Lançamento não Encontrado!" });

            return Ok(response);
        }
        [HttpGet]
        [Route("current_inventory")]
        public async Task<ActionResult> GetStockProductAsync(Guid id)
        {
            var response = _serviceStock.GetStockProduct(id);

            if (response == null)
                return NotFound(new { message = "Não Encontrado!" });

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> ListAllAsync()
        {
            var response = _serviceStock.ListAll();
            return Ok(response);
        }
        [HttpGet]
        [Route("entrada")]
        public async Task<ActionResult> ListInAsync()
        {
            var response = _serviceStock.ListIn();
            return Ok(response);
        }
        [HttpGet]
        [Route("saida")]
        public async Task<ActionResult> ListOutAsync()
        {
            var response = _serviceStock.ListOut();
            return Ok(response);
        }
        [HttpGet]
        [Route("produto")]
        public async Task<ActionResult> ListByProductAsync(Guid id)
        {
            var response = _serviceStock.ListByProduct(id);
            return Ok(response);
        }
        [HttpGet]
        [Route("user")]
        public async Task<ActionResult> ListByUserAsync(Guid id)
        {
            var response = _serviceStock.ListByUser(id);
            return Ok(response);
        }
    }
}
