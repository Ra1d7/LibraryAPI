using API.Context;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
    public async Task<List<Book>> Get()
    {
        return await _context.Books.ToListAsync();
    }

    // GET api/<BooksController>/5
    [HttpGet("{bookid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int bookid)
    {
        if (await _context.Books.Where(x => x.BookId == bookid).AnyAsync()) 
        {
            return Ok(await _context.Books.FirstOrDefaultAsync(x => x.BookId == bookid)); 
        }
        return NotFound("No book was found with that specefic Id");
    }

    // POST api/<BooksController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book)
    {
        try
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest($"Couldn't Create book.\n\n {ex.Message}");
        }
    }

    // PUT api/<BooksController>/5
    [HttpPut("{book}")]
    public async Task<IActionResult> Put([FromBody] Book book)
    {
        try
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);

        }catch (Exception ex)
        {
            return BadRequest($"Couldn't Update book \n\n {ex.Message}");
        }
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{bookid}")]
    public async Task<IActionResult> Delete(int bookid)
    {
        try
        {
            Book book = _context.Books.FirstOrDefault(x => x.BookId==bookid)!;
            _context.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(book);

        }catch (Exception ex)
        {
            return BadRequest($"Couldn't Delete book with id {bookid} \n\n {ex.Message}");
        }
    }
}