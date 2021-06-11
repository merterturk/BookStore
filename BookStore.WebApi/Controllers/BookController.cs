using BookStore.WebApi.Models;
using BookStore.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var result = _bookRepository.IsTitleExist(newBook.Title);

            if (result)
            {
                return BadRequest();
            }

            _bookRepository.Add(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updatedBook)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                return BadRequest();
            }
            _bookRepository.Update(id,updatedBook);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                return BadRequest();
            }
            _bookRepository.Delete(id);
            return Ok();
        }
    }
}
