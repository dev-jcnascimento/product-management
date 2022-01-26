using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Arguments.User;
using ProductManagement.Domain.Interface.IServices;
using ProductManagement.Security;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("v1/login")]
    public class LoginController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;

        public LoginController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }

        [HttpPost]
        public async Task<ActionResult> AuthenticateAsync(AuthenticateUserRequest request)
        {
            var response = _serviceUser.Authenticate(request);

            if (response == null)
                return NotFound(new { message = "Usuário não encontrado!" });

            var token = TokenSecurity.GenerateToken(response.Email, response.Role);
            return Ok(new { user = response, token = token });
        }
    }
}
