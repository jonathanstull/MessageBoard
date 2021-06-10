using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class UpdateToFullyDefinedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 6, 9, 22, 27, 16, 463, DateTimeKind.Local).AddTicks(1450), new DateTime(2021, 6, 9, 22, 27, 16, 463, DateTimeKind.Local).AddTicks(1530) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 6, 9, 22, 13, 19, 596, DateTimeKind.Local).AddTicks(3300), new DateTime(2021, 6, 9, 22, 13, 19, 596, DateTimeKind.Local).AddTicks(3390) });
        }
    }
}
