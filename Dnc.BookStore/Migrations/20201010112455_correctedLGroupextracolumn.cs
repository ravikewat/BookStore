using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnc.BookStore.Migrations
{
    public partial class correctedLGroupextracolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Languages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
