using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedMessageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463ef64b-a802-4126-b819-7a425594fac4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4c5a87-7ba0-4857-877c-b9c47b16ab9d");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "MessengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                newName: "IX_Messages_MessengerId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39262317-3aca-4d96-b879-c4590c806c91", null, "User", "USER" },
                    { "f725c0a7-eabe-4019-84c4-5eb49ce9881c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_MessengerId",
                table: "Messages",
                column: "MessengerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_MessengerId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39262317-3aca-4d96-b879-c4590c806c91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f725c0a7-eabe-4019-84c4-5eb49ce9881c");

            migrationBuilder.RenameColumn(
                name: "MessengerId",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MessengerId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "463ef64b-a802-4126-b819-7a425594fac4", null, "User", "USER" },
                    { "df4c5a87-7ba0-4857-877c-b9c47b16ab9d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
