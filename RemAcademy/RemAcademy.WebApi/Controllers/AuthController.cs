using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemAcademy.Business.Operations.User;
using RemAcademy.Business.Operations.User.Dtos;
using RemAcademy.WebApi.Jwt;
using RemAcademy.WebApi.Models;

namespace RemAcademy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addUserDto = new AddUserDto
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                City = request.City,
                SchoolName = request.SchoolName,
            };

            var result = await _userService.AddUser(addUserDto);
            if (result.IsSucceed)
                return Ok();
            else
                return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public  IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var result = _userService.LoginUser(new LoginUserDto { Email = request.Email, Password = request.Password });

            if (!result.IsSucceed)
                return BadRequest(result.Message);

            var user = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)
            });

            return Ok(new LoginResponse
            {
                Message = "Giriş Başarılyla tamamlandı.",
                Token = token
            });
        }
    }
}
