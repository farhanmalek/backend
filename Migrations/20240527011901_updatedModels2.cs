using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a49fa0b3-4e47-44c2-9a0a-dafce237173e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5654068-fc85-4daf-bd12-5b135b0bf32f");

            migrationBuilder.AlterColumn<string>(
                name: "User2Id",
                table: "Friendships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "User1Id",
                table: "Friendships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "505fcffc-44db-47b5-90b1-edde14368629", null, "User", "USER" },
                    { "aee3aaaa-e199-4aaa-b0a2-89ebad0a6a32", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "505fcffc-44db-47b5-90b1-edde14368629");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aee3aaaa-e199-4aaa-b0a2-89ebad0a6a32");

            migrationBuilder.AlterColumn<string>(
                name: "User2Id",
                table: "Friendships",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User1Id",
                table: "Friendships",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a49fa0b3-4e47-44c2-9a0a-dafce237173e", null, "User", "USER" },
                    { "c5654068-fc85-4daf-bd12-5b135b0bf32f", null, "Admin", "ADMIN" }
                });
        }
    }
}
