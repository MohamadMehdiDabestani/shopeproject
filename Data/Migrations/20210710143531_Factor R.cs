using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FactorR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Factor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factor_UserId",
                table: "Factor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factor_User_UserId",
                table: "Factor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factor_User_UserId",
                table: "Factor");

            migrationBuilder.DropIndex(
                name: "IX_Factor_UserId",
                table: "Factor");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Factor");
        }
    }
}
