using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class mostfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookProducts_Products_ProductId",
                table: "BookProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "BookProducts",
                newName: "prodId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookProducts_Products_prodId",
                table: "BookProducts",
                column: "prodId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookProducts_Products_prodId",
                table: "BookProducts");

            migrationBuilder.RenameColumn(
                name: "prodId",
                table: "BookProducts",
                newName: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookProducts_Products_ProductId",
                table: "BookProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
