using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class rukzooi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentSlideIndex",
                table: "Presentations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasStarted",
                table: "Presentations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSlides",
                table: "Presentations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSlideIndex",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "HasStarted",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "NumberOfSlides",
                table: "Presentations");
        }
    }
}
