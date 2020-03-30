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
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
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
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new Object());
        }
    }
}