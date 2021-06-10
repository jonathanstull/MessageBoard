using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Board> Boards { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

      modelBuilder.Entity<Board>()
      .HasMany(b => b.Messages)
      .WithOne(m => m.Board)
      .IsRequired();


      modelBuilder.Entity<Board>(b => {
        b.HasData(
          new Board
          {
            BoardId = 1,
            Name = "General",
            Description = "This is a general board",
          });
      });
      modelBuilder.Entity<Message>(m =>
      {
        m.HasData(
            new 
            {
              MessageId = 1,
              Content = "I belong to general!",
              Author = "John Doe",
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              Edited = false,
              BoardId = 1
      });

      });

      //   modelBuilder.Entity<Board>()
      //         .HasData(
      //             new Board { BoardId = 1, Name = "General", Description = "A board to post about mundane things" },
      //             new Board { BoardId = 2, Name = "Sports", Description = "A board to post about sports" });

      //     modelBuilder.Entity<Message>()
      //         .HasData(
      //             new Message { MessageId = 1, Content = "How are you?", Author = "John", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false, BoardId = 1 },
      //             new Message { MessageId = 2, Content = "I'm doing great, thank you", Author = "Kwame", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false, BoardId = 1 },
      //             new Message { MessageId = 3, Content = "What day is it?", Author = "John", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false, BoardId = 1 },
      //             new Message { MessageId = 4, Content = "I don't know", Author = "Kwame", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false, BoardId = 2 },
      //             new Message { MessageId = 5, Content = "We should buy a calendar", Author = "John", CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52), UpdatedAt = new DateTime(2008, 5, 1, 8, 30, 52), Edited = false, BoardId = 2 }
      //             );

    }
    }
}