using BookManagement.Model;
using BookManagement.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCoverController : ControllerBase
    {
        public readonly ICoverRepository _coverRepository;

        public BookCoverController(ICoverRepository coverRepository)
        {
            _coverRepository = coverRepository;
        }

        [SwaggerOperation(Summary = "Save book cover")]
        [HttpPost(), Route("Post")]
        public ActionResult Post(IFormFile file, Guid id)
        {
            try
            {
                using MemoryStream memoryStream = new();
                file.CopyTo(memoryStream);

                _coverRepository.UploadImage(memoryStream, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [SwaggerOperation(Summary = "Get book cover by id")]
        [HttpGet(), Route("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var image = await _coverRepository.GetImage(id);
                return File(image.ToArray(), "image/jpeg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}