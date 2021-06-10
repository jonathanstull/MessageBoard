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
                values: new object[] { 1, "This is a general board", "General" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "BoardId", "Content", "CreatedAt", "Edited", "UpdatedAt" },
                values: new object[] { 1, "John Doe", 1, "I belong to general!", new DateTime(2021, 6, 9, 22, 13, 19, 596, DateTimeKind.Local).AddTicks(3300), false, new DateTime(2021, 6, 9, 22, 13, 19, 596, DateTimeKind.Local).AddTicks(3390) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 1);
        }
    }
}
