using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Bll.Migrations
{
    public partial class AddedImageAndSummaryToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImagePath",
                table: "BOOK",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "BOOK",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImagePath",
                table: "BOOK");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "BOOK");
        }
    }
}
