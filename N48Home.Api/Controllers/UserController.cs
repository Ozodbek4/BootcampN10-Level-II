using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N48Home.Api.Models;
using N48Home.Api.Services;

namespace N48Home.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers() =>
            await _userService.GetAsync();

        [HttpGet("{id:Guid}")]
        public async Task<User> GetById([FromRoute] Guid Id) =>
            await _userService.GetByIdAsync(Id);

        [HttpPost]
        public async Task<User> Create([FromBody] User user) =>
            await _userService.CreateAsync(user);

        [HttpPut]
        public async Task<User> Update([FromBody] User user) =>
            await _userService.UpdateAsync(user);

        [HttpDelete]
        public async Task<User> Delete([FromRoute] Guid id) =>
            await _userService.DeleteAsync(id);
    }
}