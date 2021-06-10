using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using System.Runtime.Serialization.Json;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
  [Route("api/boards/{id}/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    private bool BoardExists(int id)
    {
      return _db.Boards.Any(b => b.BoardId == id);
    }
      private bool MessageExists(int id)
    {
      return _db.Messages.Any(m => m.MessageId == id);
    }

    // POST METHODS
    [HttpPost]
    public async Task<ActionResult<Message>> Post(int id, Message message)
    {
      
      var board = await _db.Boards.FindAsync(id);
      if (id != board.BoardId)
      {
        return BadRequest();
      }
      _db.Entry(board).State = EntityState.Modified;
      message.BoardId = id;
      _db.Messages.Update(message);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BoardExists(message.BoardId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("Post", new { id = message.MessageId }, message);

    }
  
    // GET METHODS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string author, string createdAt, string edited)
    {
      var query = _db.Messages.AsQueryable();

      if (author != null)
      {
        query = query.Where(entry => entry.Author == author);
      }

      if (createdAt != null)
      {
        DateTime createdAtDate = DateTime.Parse(createdAt);
        Console.WriteLine($"-------createdAtHour: {createdAtDate.Hour}---------createdAtMinute: {createdAtDate.Minute}");
        if (createdAtDate.Hour > 0 || createdAtDate.Minute > 0)
        {
          query = query.Where(entry => entry.CreatedAt.Month == createdAtDate.Month && entry.CreatedAt.Day == createdAtDate.Day && entry.CreatedAt.Year == createdAtDate.Year && entry.CreatedAt.Hour == createdAtDate.Hour && entry.CreatedAt.Minute == createdAtDate.Minute);
        }
        else
        {
          query = query.Where(entry => entry.CreatedAt.Month == createdAtDate.Month && entry.CreatedAt.Day == createdAtDate.Day && entry.CreatedAt.Year == createdAtDate.Year);
        }
      }
       if (edited != null)
      {
        if (edited.ToLower() == "true")
        {
          query = query.Where(entry => entry.Edited == true);
        }
        if (edited.ToLower() == "false")
        {
          query = query.Where(entry => entry.Edited == false);
        }
      }
      
      return await query.ToListAsync();
    }

   

    [HttpGet("{messageId}")]
    public async Task<ActionResult<Message>> GetMessage(int messageId)
    {
      var message = await _db.Messages.FindAsync(messageId);
      if (message == null)
      {
        return NotFound();
      }
      return message;
    }

    // PUT METHODS
    [HttpPut("{messageId}")]
    public async Task<IActionResult> Put(int messageId, Message message)
    {
      if (messageId != message.MessageId)
      {
        return BadRequest();
      }
      _db.Entry(message).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(messageId))
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

    //DELETE METHODS
    [HttpDelete("{messageId}")]
    public async Task<IActionResult> DeleteMessage(int messageId)
    {
      var message = await _db.Messages.FindAsync(messageId);
      if (message == null)
      {
        return NotFound();
      }
      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
