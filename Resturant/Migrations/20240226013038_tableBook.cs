using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class tableBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_TableId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TableId",
                table: "Books",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_TableId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TableId",
                table: "Books",
                column: "TableId",
                unique: true);
        }
    }
}
