using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    public partial class DurationAndInProgressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "PracticeLog",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InProgress",
                table: "PracticeLog",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "PracticeLog");

            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "PracticeLog");
        }
    }
}
