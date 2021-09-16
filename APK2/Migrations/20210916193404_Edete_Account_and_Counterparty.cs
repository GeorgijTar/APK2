using Microsoft.EntityFrameworkCore.Migrations;

namespace APK2.Migrations
{
    public partial class Edete_Account_and_Counterparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counterparty_Accounts_AccountId",
                table: "Counterparty");

            migrationBuilder.DropIndex(
                name: "IX_Counterparty_AccountId",
                table: "Counterparty");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Counterparty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Counterparty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counterparty_AccountId",
                table: "Counterparty",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparty_Accounts_AccountId",
                table: "Counterparty",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
