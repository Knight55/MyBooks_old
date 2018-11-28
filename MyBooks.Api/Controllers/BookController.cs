using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Bll.Services;
using MyBooks.Api.Dtos;

namespace MyBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<Book>>(_bookService.GetBooks()));
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<Book>(_bookService.GetBook(id)));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            var created = _bookService.InsertBook(_mapper.Map<Bll.Entities.Book>(book));
            return CreatedAtAction(nameof(Get), new {created.Id}, _mapper.Map<Book>(created));
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            _bookService.UpdateBook(id, _mapper.Map<Bll.Entities.Book>(book));
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}
