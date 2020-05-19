using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Database.Migrations
{
    public partial class UpdateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentDetails",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "PM_ID",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "EXPIRATION_DATE",
                table: "PaymentDetails",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "CARD_OWNER_NAME",
                table: "PaymentDetails",
                newName: "CardOwnerName");

            migrationBuilder.RenameColumn(
                name: "CARD_NUMBER",
                table: "PaymentDetails",
                newName: "CardNumber");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PaymentDetails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentDetails",
                table: "PaymentDetails",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentDetails",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "PaymentDetails",
                newName: "EXPIRATION_DATE");

            migrationBuilder.RenameColumn(
                name: "CardOwnerName",
                table: "PaymentDetails",
                newName: "CARD_OWNER_NAME");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "PaymentDetails",
                newName: "CARD_NUMBER");

            migrationBuilder.AddColumn<int>(
                name: "PM_ID",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentDetails",
                table: "PaymentDetails",
                column: "PM_ID");
        }
    }
}
