using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBook.Bll.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTHOR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: false, defaultValue: "Fantasy")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Writing_AUTHOR_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AUTHOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Writing_BOOK_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EDITION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsbnNumber = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false),
                    Format = table.Column<string>(nullable: false, defaultValue: "Paperback"),
                    BookId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDITION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDITION_BOOK_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EDITION_PUBLISHER_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "PUBLISHER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EDITION_BookId",
                table: "EDITION",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_EDITION_PublisherId",
                table: "EDITION",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Writing_AuthorId",
                table: "Writing",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Writing_BookId",
                table: "Writing",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EDITION");

            migrationBuilder.DropTable(
                name: "Writing");

            migrationBuilder.DropTable(
                name: "PUBLISHER");

            migrationBuilder.DropTable(
                name: "AUTHOR");

            migrationBuilder.DropTable(
                name: "BOOK");
        }
    }
}
