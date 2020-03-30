using System;
using System.Threading.Tasks;
using Budget.Infrastructure.Commands;
using Budget.Infrastructure.DTO;
using Budget.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser request)
        {
            await _userService.RegisterAsync(new Guid(),  request.Email, request.Firstname, request.Lastname,
                request.Passsword);

            return Created($"users/{request.Email}", new Object());
        }
    }
}