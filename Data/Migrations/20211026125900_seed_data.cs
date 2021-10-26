using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleTitle" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "Password", "PhoneNumber", "RegisterDate", "RoleId", "SecureCode", "UserAvatar", "UserName" },
                values: new object[] { 1, "Admin@gmail.com", true, "25-F9-E7-94-32-3B-45-38-85-F5-18-1F-1B-62-4D-0B", "", new DateTime(2021, 10, 26, 5, 58, 59, 915, DateTimeKind.Local).AddTicks(3516), 1, "ADU@kadkg45646@54asd@@!!", "user.jpg", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
