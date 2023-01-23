using ATMApp.Application.Models.DTOs;
using ATMApp.Application.Services.UserProcessService;
using ATMApp.Application.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProcessController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProcessService _userProcessService;

        public UserProcessController(IUserService userService, IUserProcessService userProcessService)
        {
            _userService = userService;
            _userProcessService = userProcessService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBalance(int userId)
        {
            var userBalance = await _userProcessService.GetUserBalance(userId);
            if (userBalance != null)
            {
                return Ok(userBalance);
            }
            return BadRequest("Geçersiz İşlem");
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Process(int userId, [FromBody]ProcessDTO model)
        {
            var userProcess = await _userProcessService.AddUserProcess(model,userId);

            if(userProcess != null)
            {
                return Ok(userProcess);
            }
            return BadRequest("İşlem Başarısız");
        }
        
    }
}
