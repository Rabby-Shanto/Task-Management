using Microsoft.AspNetCore.Mvc;
using Todo.Application.Handlers.Contracts;
using Todo.Domain.RequestModel;
using Todo.Infrastructure.Contracts;
using Todo.Presentation.Controllers.Base;

namespace Todo.Presentation.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IUserHandler _userHandler;

        public AuthController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var response = await _userHandler.RegisterUser(request);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var response = await _userHandler.LoginUser(request);
            return Ok(response);
        }


    }
}