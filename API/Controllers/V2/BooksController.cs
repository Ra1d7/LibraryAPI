using API.Context;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.V2;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class BooksController : ControllerBase
{
    private readonly ElibraryDbContext _context;

    public BooksController(ElibraryDbContext context)
    {
        _context = context;
    }
    // GET: api/<BooksController>
    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<Book> Get()
    {
        return _context.Books.ToList();
    }

    // GET api/<BooksController>/5
    [HttpGet("{bookid}")]
    [AllowAnonymous]
    public IActionResult Get(int bookid)
    {
        if(_context.Books.Where(x => x.BookId == bookid).Any()) { return Ok(_context.Books.FirstOrDefault(x => x.BookId == bookid)); }
        return NotFound("No book was found with that specefic Id");
    }

    // POST api/<BooksController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<BooksController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}