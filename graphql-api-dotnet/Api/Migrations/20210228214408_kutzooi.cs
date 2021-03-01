using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kutzooi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Presentations",
                type: "TEXT",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Presentations");
        }
    }
}
