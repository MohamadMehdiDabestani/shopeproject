using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PostEdite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostDes",
                table: "Post",
                newName: "PostDescription");

            migrationBuilder.AddColumn<string>(
                name: "AltImage",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrowserDescription",
                table: "Post",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrowserTitle",
                table: "Post",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltImage",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "BrowserDescription",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "BrowserTitle",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "PostDescription",
                table: "Post",
                newName: "PostDes");
        }
    }
}
