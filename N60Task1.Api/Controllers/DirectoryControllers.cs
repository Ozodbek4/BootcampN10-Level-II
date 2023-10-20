using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N60Task1.Api.Service;

namespace N60Task1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryControllers : ControllerBase
    {
        [HttpGet]
        public async ValueTask<IActionResult> Get([FromServices] SearchFileService search, string fileName) =>
            Ok(search.SearchFolder("D:\\",fileName));
    }
}
