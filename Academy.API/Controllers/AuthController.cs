using Academy.AuthenticationService.Model;
using Academy.Domain.Entities;
using Core.Security.Jwt.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IJwtAuthService jwtAuthService, UserManager<AppUser> userManager)
        {
            _jwtAuthService = jwtAuthService;
            _userManager = userManager;
        }

        public class LoginVm
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginVm vm)
        {
            var existUser = await _userManager.FindByNameAsync(vm.username);

            if (existUser == null) return BadRequest();

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(existUser, vm.password);

            if (!passwordIsCorrect) return BadRequest();

            var roles = (await _userManager.GetRolesAsync(existUser)).ToList();
            var requestModel = new JwtTokenRequestModel
            {
                Username = vm.username,
                Password = vm.password,
                Roles = roles,
                Email = existUser.Email!
            };

            var tokenResponseModel = await _jwtAuthService.CreateToken(requestModel);

            return Ok(tokenResponseModel);
        }
    }
}
