using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Bll.Migrations
{
    public partial class RenamedWritingsToBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOK_RATING_RatingId",
                table: "BOOK");

            migrationBuilder.DropTable(
                name: "WRITING");

            migrationBuilder.DropIndex(
                name: "IX_BOOK_RatingId",
                table: "BOOK");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "BOOK");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "RATING",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BOOKAUTHOR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKAUTHOR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOOKAUTHOR_AUTHOR_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AUTHOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOKAUTHOR_BOOK_BookId",
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

            migrationBuilder.CreateIndex(
                name: "IX_BOOKAUTHOR_AuthorId",
                table: "BOOKAUTHOR",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKAUTHOR_BookId",
                table: "BOOKAUTHOR",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_RATING_BOOK_BookId",
                table: "RATING",
                column: "BookId",
                principalTable: "BOOK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RATING_BOOK_BookId",
                table: "RATING");

            migrationBuilder.DropTable(
                name: "BOOKAUTHOR");

            migrationBuilder.DropIndex(
                name: "IX_RATING_BookId",
                table: "RATING");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "RATING");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "BOOK",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WRITING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WRITING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WRITING_AUTHOR_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AUTHOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WRITING_BOOK_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_RatingId",
                table: "BOOK",
                column: "RatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WRITING_AuthorId",
                table: "WRITING",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_WRITING_BookId",
                table: "WRITING",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOK_RATING_RatingId",
                table: "BOOK",
                column: "RatingId",
                principalTable: "RATING",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
