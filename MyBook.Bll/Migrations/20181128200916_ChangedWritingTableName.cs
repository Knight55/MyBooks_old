using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Bll.Migrations
{
    public partial class ChangedWritingTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writing_AUTHOR_AuthorId",
                table: "Writing");

            migrationBuilder.DropForeignKey(
                name: "FK_Writing_BOOK_BookId",
                table: "Writing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writing",
                table: "Writing");

            migrationBuilder.RenameTable(
                name: "Writing",
                newName: "WRITING");

            migrationBuilder.RenameIndex(
                name: "IX_Writing_BookId",
                table: "WRITING",
                newName: "IX_WRITING_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Writing_AuthorId",
                table: "WRITING",
                newName: "IX_WRITING_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AUTHOR",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WRITING",
                table: "WRITING",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WRITING_AUTHOR_AuthorId",
                table: "WRITING",
                column: "AuthorId",
                principalTable: "AUTHOR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WRITING_BOOK_BookId",
                table: "WRITING",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_AUTHOR_AuthorId",
                table: "WRITING");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_BOOK_BookId",
                table: "WRITING");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WRITING",
                table: "WRITING");

            migrationBuilder.RenameTable(
                name: "WRITING",
                newName: "Writing");

            migrationBuilder.RenameIndex(
                name: "IX_WRITING_BookId",
                table: "Writing",
                newName: "IX_Writing_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_WRITING_AuthorId",
                table: "Writing",
                newName: "IX_Writing_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AUTHOR",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writing",
                table: "Writing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Writing_AUTHOR_AuthorId",
                table: "Writing",
                column: "AuthorId",
                principalTable: "AUTHOR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writing_BOOK_BookId",
                table: "Writing",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
