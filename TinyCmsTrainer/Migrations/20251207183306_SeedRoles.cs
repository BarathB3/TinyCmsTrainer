using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TinyCmsTrainer.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaLibrary_Users_UserId",
                table: "MediaLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaLibrary",
                table: "MediaLibrary");

            migrationBuilder.RenameTable(
                name: "MediaLibrary",
                newName: "MediaItems");

            migrationBuilder.RenameIndex(
                name: "IX_MediaLibrary_UserId",
                table: "MediaItems",
                newName: "IX_MediaItems_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaItems",
                table: "MediaItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Editor" },
                    { 3, "Author" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_Users_UserId",
                table: "MediaItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_Users_UserId",
                table: "MediaItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaItems",
                table: "MediaItems");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "MediaItems",
                newName: "MediaLibrary");

            migrationBuilder.RenameIndex(
                name: "IX_MediaItems_UserId",
                table: "MediaLibrary",
                newName: "IX_MediaLibrary_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaLibrary",
                table: "MediaLibrary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaLibrary_Users_UserId",
                table: "MediaLibrary",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
