using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnc.BookStore.Migrations
{
    public partial class addnewbookcove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCoverUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCoverUrl",
                table: "Books");
        }
    }
}
