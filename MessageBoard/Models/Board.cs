using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Board
  {
    public int BoardId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Message> Messages { get; set; }
  }
}