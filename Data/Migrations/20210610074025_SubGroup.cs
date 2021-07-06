using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SubGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubGroupId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Group",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubGroupId",
                table: "Product",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ParentId",
                table: "Group",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Group_ParentId",
                table: "Group",
                column: "ParentId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Group_SubGroupId",
                table: "Product",
                column: "SubGroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Group_ParentId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Group_SubGroupId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubGroupId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Group_ParentId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "SubGroupId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Group");
        }
    }
}
