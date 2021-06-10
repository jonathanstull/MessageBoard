using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace MessageBoard.Models
{
  public class Message
  {
    
    public int MessageId { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Edited { get; set; }
    [ForeignKey("Board")]
    public int BoardId { get; set; }
    public  Board Board { get; set; }
  }
}