using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Updatefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactorId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Factor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Factor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_FactorId",
                table: "Product",
                column: "FactorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Factor_FactorId",
                table: "Product",
                column: "FactorId",
                principalTable: "Factor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Factor_FactorId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_FactorId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FactorId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Factor");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Factor");
        }
    }
}
