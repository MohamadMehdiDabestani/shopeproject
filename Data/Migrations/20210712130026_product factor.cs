using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class productfactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FactorProduct",
                columns: table => new
                {
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    productsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorProduct", x => new { x.FactorId, x.productsId });
                    table.ForeignKey(
                        name: "FK_FactorProduct_Factor_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactorProduct_Product_productsId",
                        column: x => x.productsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactorProduct_productsId",
                table: "FactorProduct",
                column: "productsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorProduct");

            migrationBuilder.AddColumn<int>(
                name: "FactorId",
                table: "Product",
                type: "int",
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
    }
}
