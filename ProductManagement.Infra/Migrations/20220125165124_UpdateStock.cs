using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Infra.Migrations
{
    public partial class UpdateStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Out",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Stock");

            migrationBuilder.AddColumn<bool>(
                name: "In",
                table: "Stock",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Out",
                table: "Stock",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
