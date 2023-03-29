using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherCore.BlogServer.Migrations
{
    public partial class updatePoststatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "AppPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDateTime",
                table: "AppPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppPosts");

            migrationBuilder.DropColumn(
                name: "PublishDateTime",
                table: "AppPosts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppPosts");
        }
    }
}
