﻿using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Bll.Services;
using MyBooks.Api.Dtos;

namespace MyBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<Book>>(_bookService.GetBooks()));
        }

        /// <summary>
        /// Get a specific book with the given identifier.
        /// </summary>
        /// <param name="id">Identifier of the book.</param>
        /// <returns>Returns a specific book with the given identifier.</returns>
        /// <response code="200">Returns a specific book with the given identifier.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<Book>(_bookService.GetBook(id)));
        }

        [HttpGet("Search/{searchTerm}")]
        [ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        public IActionResult Search(string searchTerm)
        {
            return Ok(_mapper.Map<List<Book>>(_bookService.SearchBooks(searchTerm)));
        }
        
        /// <summary>
        /// Insert the given book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), (int)HttpStatusCode.BadRequest)]
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
