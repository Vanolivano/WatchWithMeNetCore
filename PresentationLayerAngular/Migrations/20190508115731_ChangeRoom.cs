using Microsoft.EntityFrameworkCore.Migrations;

namespace PresentationLayerAngular.Migrations
{
    public partial class ChangeRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUrlVideo",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentUrlVideo",
                table: "Rooms",
                nullable: true);
        }
    }
}
