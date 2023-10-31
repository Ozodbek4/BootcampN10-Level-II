using Microsoft.AspNetCore.Mvc;
using N66Home.Api.Domain.Entities;
using N66Home.Api.Domain.Services.Interfaces;

namespace N66Home.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id:Guid}")]
        public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _bookService.GetById(id));

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync() =>
            Ok(await _bookService.GetAsync());

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromBody] Book book) =>
            Ok(await _bookService.CreateAsync(book));

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromBody] Book book) =>
            Ok(await _bookService.UpdateAsync(book));

        [HttpDelete("{id:Guid}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id) =>
            Ok(await _bookService.DeleteAsync(id));
    }
}
