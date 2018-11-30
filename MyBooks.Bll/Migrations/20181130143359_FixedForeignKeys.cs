using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Bll.Migrations
{
    public partial class FixedForeignKeys : Migration
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
                name: "FK_RATING_BOOK_BookId",
                table: "RATING");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_AUTHOR_AuthorId",
                table: "WRITING");

            migrationBuilder.DropForeignKey(
                name: "FK_WRITING_BOOK_BookId",
                table: "WRITING");

            migrationBuilder.DropIndex(
                name: "IX_RATING_BookId",
                table: "RATING");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "RATING");

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

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "BOOK",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_RatingId",
                table: "BOOK",
                column: "RatingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BOOK_RATING_RatingId",
                table: "BOOK",
                column: "RatingId",
                principalTable: "RATING",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOK_RATING_RatingId",
                table: "BOOK");

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

            migrationBuilder.DropIndex(
                name: "IX_BOOK_RatingId",
                table: "BOOK");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "BOOK");

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

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "RATING",
                nullable: false,
                defaultValue: 0);

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
                name: "FK_RATING_BOOK_BookId",
                table: "RATING",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
