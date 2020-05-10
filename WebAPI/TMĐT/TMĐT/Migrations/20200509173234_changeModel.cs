using Microsoft.EntityFrameworkCore.Migrations;

namespace TMĐT.Migrations
{
    public partial class changeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "PMId",
                table: "PaymentDetails",
                newName: "PM_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "PM_ID",
                table: "PaymentDetails",
                newName: "PMId");
        }
    }
}
