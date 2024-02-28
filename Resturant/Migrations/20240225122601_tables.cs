using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Tables_tableId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_tableId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "tableId",
                table: "Books",
                newName: "TableId");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_TableId",
                table: "Books",
                column: "TableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Tables_TableId",
                table: "Books",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "tableId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Tables_TableId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TableId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Books",
                newName: "tableId");

            migrationBuilder.AlterColumn<int>(
                name: "tableId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Books_tableId",
                table: "Books",
                column: "tableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Tables_tableId",
                table: "Books",
                column: "tableId",
                principalTable: "Tables",
                principalColumn: "tableId");
        }
    }
}
