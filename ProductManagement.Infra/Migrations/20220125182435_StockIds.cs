using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Infra.Migrations
{
    public partial class StockIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UserId",
                table: "Stock",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_UserId",
                table: "Stock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                columns: new[] { "UserId", "ProductId" });
        }
    }
}
