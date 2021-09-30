using Microsoft.EntityFrameworkCore.Migrations;

namespace APK2.Migrations
{
    public partial class Edete_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterpartyId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CounterpartyId",
                table: "Accounts",
                column: "CounterpartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Counterparty_CounterpartyId",
                table: "Accounts",
                column: "CounterpartyId",
                principalTable: "Counterparty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Counterparty_CounterpartyId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CounterpartyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CounterpartyId",
                table: "Accounts");
        }
    }
}
