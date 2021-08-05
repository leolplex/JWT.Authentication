
using System;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = null;
        private ApplicationDbContext appdbcontext = null;

        public UserController(IUserService userService, ApplicationDbContext _adb)
        {
            _userService = userService;
            appdbcontext = _adb;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            try
            {
                var result = await _userService.RegisterAsync(model);
                if (result.StartsWith("Error"))
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            if (string.IsNullOrEmpty(result.Token))
                return NotFound(" " + result.Message);

            return Ok(result.Token);
        }
      
    }
}