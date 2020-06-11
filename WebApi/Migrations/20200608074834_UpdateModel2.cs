using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UpdateModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastUpdateBy",
                table: "Products",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Products",
                type: "DateTime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdateBy",
                table: "Producers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Producers",
                type: "DateTime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Producers");
        }
    }
}
