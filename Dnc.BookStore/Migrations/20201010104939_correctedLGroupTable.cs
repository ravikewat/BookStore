using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnc.BookStore.Migrations
{
    public partial class correctedLGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageGroup_LanguageGroupId",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageGroup",
                table: "LanguageGroup");

            migrationBuilder.RenameTable(
                name: "LanguageGroup",
                newName: "LanguageGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageGroups",
                table: "LanguageGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageGroups_LanguageGroupId",
                table: "Languages",
                column: "LanguageGroupId",
                principalTable: "LanguageGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageGroups_LanguageGroupId",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageGroups",
                table: "LanguageGroups");

            migrationBuilder.RenameTable(
                name: "LanguageGroups",
                newName: "LanguageGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageGroup",
                table: "LanguageGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageGroup_LanguageGroupId",
                table: "Languages",
                column: "LanguageGroupId",
                principalTable: "LanguageGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
