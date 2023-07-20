using BookManagement.Model;
using BookManagement.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookManagementController : ControllerBase
    {
        public readonly IBookBusiness _bookBusiness;

        public BookManagementController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [SwaggerOperation(Summary = "Get all books already informed.")]
        [HttpGet(), Route("GetAllBooks")]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                return _bookBusiness.GetAll();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [SwaggerOperation(Summary = "Create a new book data. The Book Id will be created.")]
        [HttpPost(Name = "Post")]
        public ActionResult<Book> Post(Book book)
        {
            try
            {
                _bookBusiness.Insert(book);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [SwaggerOperation(Summary = "Create a new book data.")]
        [HttpPatch(Name = "Patch")]
        public ActionResult<Book> Patch(Book book)
        {
            try
            {
                _bookBusiness.Update(book);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [SwaggerOperation(Summary = "Get book by id")]
        [HttpGet(), Route("Get")]

        public ActionResult<Book> Get(Guid id)
        {
            try
            {
                return _bookBusiness.Get(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [SwaggerOperation(Summary = "Delete book by id.")]
        [HttpDelete(Name = "Delete")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _bookBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}