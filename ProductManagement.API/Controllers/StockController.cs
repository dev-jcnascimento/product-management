using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductManagement.Domain.Arguments.Stock;
using ProductManagement.Domain.Interface.IServices;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("v1/stocks")]
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
        public async Task<ActionResult> DeleteAsync([BindRequired, FromQuery] Guid id)
        {
            var stock = _serviceStock.Delete(id);

            if (stock == null) return NotFound(new { message = "Id não Encontrado!" });
            return NoContent();
        }

        [HttpGet]
        [Route("stock_id")]
        public async Task<ActionResult> GetByIdAsyn([BindRequired, FromQuery] Guid id)
        {
            var response = _serviceStock.GetById(id);

            if (response == null) return NotFound(new { message = "Lançamento não encontrado!" });
            return Ok(response);
        }
        [HttpGet]
        [Route("product_inventory_id")]
        public async Task<ActionResult> GetStockProductAsync([BindRequired, FromQuery] Guid id)
        {
            var response = _serviceStock.GetStockProduct(id);

            if (response == null) return NotFound(new { message = "Id produto não encontrado!" });
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
        [Route("product_id")]
        public async Task<ActionResult> ListByProductAsync([BindRequired, FromQuery] Guid id)
        {
            var response = _serviceStock.ListByProduct(id);

            if (response == null) return BadRequest(new { message = "Id produto não encontrado!" });
            if (response.Count() == 0) return NoContent();
            return Ok(response);
        }
        [HttpGet]
        [Route("user_id")]
        public async Task<ActionResult> ListByUserAsync([BindRequired, FromQuery] Guid id)
        {
            var response = _serviceStock.ListByUser(id);

            if (response == null) return BadRequest(new { message = "Id user não encontrado!" });
            if (response.Count() == 0) return NoContent();
            return Ok(response);
        }
    }
}
