using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthBy",
                table: "Producers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuthDate",
                table: "Producers",
                type: "DateTime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthStatus",
                table: "Producers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Producers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Producers",
                type: "DateTime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthBy",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "AuthDate",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "AuthStatus",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Producers");
        }
    }
}
