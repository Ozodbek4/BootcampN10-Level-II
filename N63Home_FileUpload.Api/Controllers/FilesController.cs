using Microsoft.AspNetCore.Mvc;
using N63Home_FileUpload.Api.Services;

namespace N63Home_FileUpload.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;

        public FilesController(FileService fileService) =>
            _fileService = fileService;


        [HttpPost]
        public async ValueTask<IActionResult> UploadAsync(Guid userId, string directoryName, IFormFile fileStream) =>
            Ok(await _fileService.Upload(userId, directoryName, fileStream));

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(string filePath) =>
            Ok(await _fileService.Delete(filePath));
    }
}
