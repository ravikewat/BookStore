using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnc.BookStore.Migrations
{
    public partial class addedLanguageGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "Languages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageGroupId",
                table: "Languages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LanguageGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageGroupId",
                table: "Languages",
                column: "LanguageGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageGroup_LanguageGroupId",
                table: "Languages",
                column: "LanguageGroupId",
                principalTable: "LanguageGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageGroup_LanguageGroupId",
                table: "Languages");

            migrationBuilder.DropTable(
                name: "LanguageGroup");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageGroupId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageGroupId",
                table: "Languages");
        }
    }
}
