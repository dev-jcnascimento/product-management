using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductManagement.Domain.Arguments.User;
using ProductManagement.Domain.Interface.IServices;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateUserRequest request)
        {
            if (request == null) return BadRequest(new { message = "Cadastro não pode ser vazio!" });

            var response = _serviceUser.Create(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> ListAsync()
        {
            var response = _serviceUser.List();
            return Ok(response);
        }

        [HttpGet]
        [Route("user_id")]
        public async Task<ActionResult> GetByIdAsyn([BindRequired, FromQuery] Guid id)
        {
            var response = _serviceUser.GetById(id);

            if (response == null) return NotFound(new { message = "User não Encontrado!" });
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAsyn(UpdateUserRequest request)
        {
            var response = _serviceUser.Update(request);

            if (response == null) return NotFound(new { message = "User não Encontrado!" });
            return Ok(response);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAdminAsync(UpdateAdminUserRequest request)
        {
            var response = _serviceUser.UpdateAdmin(request.Id, request.Role);

            if (response == null) return NotFound(new { message = "User não Encontrado!" });
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete([BindRequired, FromQuery] Guid id)
        { 
            var user = _serviceUser.Delete(id);

            if (user == null) return NotFound(new { message = "Id não Encontrado!" });
            return NoContent();
        }
    }
}
