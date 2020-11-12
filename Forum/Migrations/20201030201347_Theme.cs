using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations {
    public partial class Theme : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Messages");
        }
    }
}
