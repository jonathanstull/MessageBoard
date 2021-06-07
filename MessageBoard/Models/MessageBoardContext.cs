using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                .HasData(
                    new Message { MessageId = 1, Content = "How are you?", Author = "John", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false },
                    new Message { MessageId = 2, Content = "I'm doing great, thank you", Author = "Kwame", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false },
                    new Message { MessageId = 3, Content = "What day is it?", Author = "John", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false },
                    new Message { MessageId = 4, Content = "I don't know", Author = "Kwame", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false },
                    new Message { MessageId = 5, Content = "We should buy a calendar", Author = "John", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false }
                );
        }
    }

}
//var date1 = new DateTime(2008, 5, 1, 8, 30, 52);
// 01/01/0001 00:00:00