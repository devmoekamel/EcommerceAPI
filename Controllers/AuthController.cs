using Ecommerce.DTOS;
using Ecommerce.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var authResult = await _authService.RegisterAsync(model);
            if (!authResult.IsAuthenticated) return BadRequest(authResult.Message);

            return Ok(authResult);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var authResult = await _authService.LoginAsync(model);
            if (!authResult.IsAuthenticated) return BadRequest(authResult.Message);

            return Ok(authResult);
        }

        [HttpPost("Role")]
        public async Task<IActionResult> AddRole(AddRoleDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);
            if (!string.IsNullOrWhiteSpace(result)) return BadRequest(result);

            return Ok(new { status = "success", Result = model });
        }
    }
}
