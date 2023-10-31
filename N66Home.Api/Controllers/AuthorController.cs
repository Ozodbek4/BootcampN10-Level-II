using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N66Home.Api.Domain.Entities;
using N66Home.Api.Domain.Services.Interfaces;

namespace N66Home.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id:Guid}")]
        public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _authorService.GetById(id));

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync([FromBody] IEnumerable<Author> authors) =>
            Ok(await _authorService.GetAsync(authors));

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromBody] Author author) =>
            Ok(await _authorService.CreateAsync(author));

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromBody] Author author) =>
            Ok(await _authorService.UpdateAsync(author));

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id) =>
            Ok(await _authorService.DeleteAsync(id));
    }
}
