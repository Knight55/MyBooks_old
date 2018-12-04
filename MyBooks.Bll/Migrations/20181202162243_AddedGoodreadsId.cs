using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Bll.Migrations
{
    public partial class AddedGoodreadsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoodreadsId",
                table: "BOOK",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "BOOK",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodreadsId",
                table: "BOOK");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "BOOK");
        }
    }
}
