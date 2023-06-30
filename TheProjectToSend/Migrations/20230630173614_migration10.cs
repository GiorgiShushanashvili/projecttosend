using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheProjectToSend.Migrations
{
    public partial class migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genderr",
                table: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gender",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gender");

            migrationBuilder.AddColumn<int>(
                name: "Genderr",
                table: "Gender",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
