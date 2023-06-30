using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheProjectToSend.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonGender",
                table: "Gender",
                newName: "Genderr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genderr",
                table: "Gender",
                newName: "PersonGender");
        }
    }
}
