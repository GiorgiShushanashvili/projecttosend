using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheProjectToSend.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonGender",
                table: "Gender",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonGender",
                table: "Gender");
        }
    }
}
