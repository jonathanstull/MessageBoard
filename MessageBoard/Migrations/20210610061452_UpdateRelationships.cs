using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class UpdateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 6, 9, 23, 14, 52, 394, DateTimeKind.Local).AddTicks(6670), new DateTime(2021, 6, 9, 23, 14, 52, 394, DateTimeKind.Local).AddTicks(6730) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 6, 9, 22, 42, 11, 229, DateTimeKind.Local).AddTicks(660), new DateTime(2021, 6, 9, 22, 42, 11, 229, DateTimeKind.Local).AddTicks(730) });
        }
    }
}
