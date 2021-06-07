using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Author = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Edited = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "Content", "CreatedAt", "Edited", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "John", "How are you?", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 2, "Kwame", "I'm doing great, thank you", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 3, "John", "What day is it?", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 4, "Kwame", "I don't know", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 5, "John", "We should buy a calendar", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
