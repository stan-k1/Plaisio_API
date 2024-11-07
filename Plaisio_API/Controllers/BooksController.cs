using Microsoft.AspNetCore.Mvc;
using Plaisio_API.DTOs;
using Plaisio_API.Services;

namespace Plaisio_API.Controllers;

[ApiController] 
[Route("api/[Controller]")] //api/books/
public class BooksController : ControllerBase
{
    private readonly IBookService _service;
    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetAllBooks()
    {
        List<BookDto> books = await _service.GetAllBooks();
        return Ok(books); //Status Code 200
    }

    [HttpGet, Route("{id}")]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        BookDto? book = await _service.GetBook(id);
        if (book == null) return BadRequest(); //400
        else return Ok(book); //200
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook(BookDto dto)
    {
        return await _service.CreateBook(dto);
    }
}

