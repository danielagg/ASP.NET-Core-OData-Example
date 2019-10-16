using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class _002_AddedModificationDateToPlaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Playlists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2019, 10, 15, 21, 11, 2, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2019, 10, 16, 11, 1, 32, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2019, 10, 16, 14, 16, 12, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModifiedOn",
                value: new DateTime(2019, 10, 13, 23, 59, 23, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Playlists");
        }
    }
}
