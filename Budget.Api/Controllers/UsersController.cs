using System.Threading.Tasks;
using Budget.Api.Commands.Users;
using Budget.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Budget.Infrastructure.DTO;

namespace Budget.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost("")]
        public async Task Post([FromBody] CreateUser request)
        {
            await _userService.RegisterAsync(request.Id, request.Email, request.Firstname, request.Lastname,
                request.Password);
        }
    }
}