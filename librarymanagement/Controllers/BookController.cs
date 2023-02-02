
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Web.Dtos;
using LibraryManagement.Web.Extensions;

namespace librarymanagement.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {

        public IBookProvider _bookService;
        private readonly ILogger<BookController> _logger;
        
        

        public BookController(IBookProvider service  ,ILogger <BookController> logger )
        {
            _bookService = service;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<BookDto> AddBook(BookDto book)
        {
            try
            {
                var model = book.AsModel();
                _bookService.AddBook(model);
                _logger.LogInformation("  one book added");
                return CreatedAtAction(nameof(GetBook), new { id = model.Id }, model);
            }
            catch (Exception)
            {
                return NotFound();

            }
        }
        [HttpPut("update")]
        public ActionResult UpdateBook(int id, BookDto data)   
        {
            try
            {
                var book = _bookService.GetBook(id);
                if(book == null )
                {
                    return NotFound();
                }
                _logger.LogInformation("book updated");
                _bookService.UpdateBook(data.AsModel());
                return NoContent();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            try
            {
                return Ok(_bookService.GetBooks().Select(x=>x.AsDto()));
            }   
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("/paged/{pgno}")]
        public ActionResult<List<BookDto>> GetBooks(int pgno) 
        {
            try
            {
               return Ok(_bookService.pagedBooks(pgno));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("{id}")]
        public  ActionResult<BookModel> GetBook(int id)
        {
            try
            {
                var book = _bookService.GetBook(id);
                if(book == null)
                {
                    return NotFound();
                }

                return Ok(book.AsDto());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            try
            {
                var book = _bookService.GetBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                _bookService.DeleteBook(id);
                _logger.LogCritical($" Book {id} deleted");

                return NoContent();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("search/{searchstring}")]
        public  ActionResult<IEnumerable<BookModel>> Search(string searchstring)
        {
            try
            {
                var result = _bookService.Search(searchstring);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
        
        [HttpGet("filter")]

        public async Task<ActionResult<BookDto>> Filter(string author)
        {
            var result = _bookService.Filter(author).Select(x=>x.AsDto());
            return Ok(result);
        }
    }
}
