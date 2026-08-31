using Microsoft.AspNetCore.Mvc;

namespace WimabEventApp.Controllers
{
    [Route("api/uploads")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("gift-image")]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public async Task<IActionResult> UploadGiftImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Please select an image." });
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest(new
                {
                    message = "Only JPG, JPEG, PNG and WEBP images are allowed."
                });
            }

            if (file.Length > 5 * 1024 * 1024)
            {
                return BadRequest(new
                {
                    message = "Image must be smaller than 5 MB."
                });
            }

            var uploadsFolder = Path.Combine(
                _environment.WebRootPath,
                "images",
                "custom-gifts"
            );

            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid():N}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"/images/custom-gifts/{fileName}";

            return Ok(new
            {
                imageUrl
            });
        }
    }
}
