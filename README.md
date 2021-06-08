
class Message
  int MessageId
  string Content
  string Author
  DateTime CreatedAt
  DateTime UpdatedAt
  bool Edited

class Board
  int BoardId
  string Name

class BoardMessage
  int BoardMessageId
  int BoardId
  int MessageId

  
Further exploration
  public virtual ApplicationUser user
  threaded comments/replies