using ATMApp.Application.Models.DTOs;
using ATMApp.Application.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO model)
        {
            if(ModelState.IsValid)
            {
                await _userService.CreateUser(model);
                return Ok("Kullanıcı Başarılı Bir Şekilde Eklenmiştir");
            }
            return StatusCode(500);
        }
    }
}
