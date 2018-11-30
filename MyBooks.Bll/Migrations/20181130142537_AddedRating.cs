using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Bll.Migrations
{
    public partial class AddedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EDITION_BOOK_BookId",
                table: "EDITION");

            migrationBuilder.DropForeignKey(
                name: "FK_EDITION_PUBLISHER_PublisherId",
                table: "EDITION");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_AUTHOR_AuthorId",
                table: "WRITING");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_BOOK_BookId",
                table: "WRITING");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "WRITING",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "WRITING",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "EDITION",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "EDITION",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AUTHOR",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "RATING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RATING_BOOK_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RATING_BookId",
                table: "RATING",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EDITION_BOOK_BookId",
                table: "EDITION",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDITION_PUBLISHER_PublisherId",
                table: "EDITION",
                column: "PublisherId",
                principalTable: "PUBLISHER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WRITING_AUTHOR_AuthorId",
                table: "WRITING",
                column: "AuthorId",
                principalTable: "AUTHOR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WRITING_BOOK_BookId",
                table: "WRITING",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EDITION_BOOK_BookId",
                table: "EDITION");

            migrationBuilder.DropForeignKey(
                name: "FK_EDITION_PUBLISHER_PublisherId",
                table: "EDITION");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_AUTHOR_AuthorId",
                table: "WRITING");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_BOOK_BookId",
                table: "WRITING");

            migrationBuilder.DropTable(
                name: "RATING");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "WRITING",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "WRITING",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "EDITION",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "EDITION",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AUTHOR",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EDITION_BOOK_BookId",
                table: "EDITION",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EDITION_PUBLISHER_PublisherId",
                table: "EDITION",
                column: "PublisherId",
                principalTable: "PUBLISHER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
