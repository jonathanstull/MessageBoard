using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[] { 1, "A board to post about mundane things", "General" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[] { 2, "A board to post about sports", "Sports" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "BoardId", "Content", "CreatedAt", "Edited", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "John", 1, "How are you?", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 2, "Kwame", 1, "I'm doing great, thank you", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 3, "John", 1, "What day is it?", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 4, "Kwame", 2, "I don't know", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 5, "John", 2, "We should buy a calendar", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 2);
        }
    }
}
