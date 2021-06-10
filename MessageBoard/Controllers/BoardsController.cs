using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoardsController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    private bool BoardExists(int id)
    {
      return _db.Boards.Any(b => b.BoardId == id);
    }

    public BoardsController(MessageBoardContext db)
    {
      _db = db;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult<Board>> Post(Board board)
    {
      _db.Boards.Add(board);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = board.BoardId }, board);
    }
     

    // GET
   [HttpGet]
    public async Task<ActionResult<IEnumerable<Board>>> Get(string name, string descriptor)
    {
      var query = _db.Boards.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (descriptor != null)
      {
        query = query.Where(entry => entry.Description.Contains(descriptor));
      }
      query.Include(entity => entity.Messages);

      return await query.ToListAsync();
    }

    // GET with id
    [HttpGet("{id}")]
public async Task<ActionResult<Board>> GetBoard(int id)
{
      var board = await _db.Boards.Include(b => b.Messages)
      .FirstOrDefaultAsync(b => b.BoardId == id);
      
      if (board == null)
      {
        return NotFound();
      }

      return board;
    }
    
    // PUT with id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Board board)
    {
      if (id != board.BoardId)
      {
        return BadRequest();
      }
      _db.Entry(board).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BoardExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    // DELETE with id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBoard(int id)
    {
      var board = await _db.Boards.FindAsync(id);

      if (board == null)
      {
        return NotFound();
      }
      _db.Boards.Remove(board);
      await _db.SaveChangesAsync();
      
      return NoContent();
    }
  }
}