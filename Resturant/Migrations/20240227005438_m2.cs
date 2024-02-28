using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookProducts",
                table: "BookProducts");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "BookProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookProducts",
                table: "BookProducts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_BookProducts_prodId",
                table: "BookProducts",
                column: "prodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookProducts",
                table: "BookProducts");

            migrationBuilder.DropIndex(
                name: "IX_BookProducts_prodId",
                table: "BookProducts");

            migrationBuilder.DropColumn(
                name: "id",
                table: "BookProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookProducts",
                table: "BookProducts",
                columns: new[] { "prodId", "bookId" });
        }
    }
}
