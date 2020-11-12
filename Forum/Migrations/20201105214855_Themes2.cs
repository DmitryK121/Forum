using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class Themes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Themes_Themeid",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "themeName",
                table: "Themes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Themes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Post",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "Post",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Post",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Themeid",
                table: "Post",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Themeid",
                table: "Post",
                newName: "IX_Post_ThemeId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Themes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Themes_ThemeId",
                table: "Post",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Themes_ThemeId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Themes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Themes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Post",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Post",
                newName: "Themeid");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Post",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Post",
                newName: "content");

            migrationBuilder.RenameIndex(
                name: "IX_Post_ThemeId",
                table: "Post",
                newName: "IX_Post_Themeid");

            migrationBuilder.AddColumn<string>(
                name: "themeName",
                table: "Themes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Themes_Themeid",
                table: "Post",
                column: "Themeid",
                principalTable: "Themes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
