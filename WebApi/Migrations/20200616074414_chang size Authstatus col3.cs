using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class changsizeAuthstatuscol3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthStatusName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AuthStatusName",
                table: "Producers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthStatusName",
                table: "Products",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthStatusName",
                table: "Producers",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }
    }
}
