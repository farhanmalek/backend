using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2859eb07-991f-4bce-b9f9-a798324f760a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4807493a-14ec-4dd4-9b0e-bd700af98884");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a49fa0b3-4e47-44c2-9a0a-dafce237173e", null, "User", "USER" },
                    { "c5654068-fc85-4daf-bd12-5b135b0bf32f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a49fa0b3-4e47-44c2-9a0a-dafce237173e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5654068-fc85-4daf-bd12-5b135b0bf32f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2859eb07-991f-4bce-b9f9-a798324f760a", null, "User", "USER" },
                    { "4807493a-14ec-4dd4-9b0e-bd700af98884", null, "Admin", "ADMIN" }
                });
        }
    }
}
