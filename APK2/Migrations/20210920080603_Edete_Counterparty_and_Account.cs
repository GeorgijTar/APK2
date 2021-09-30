using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APK2.Migrations
{
    public partial class Edete_Counterparty_and_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSpan",
                table: "Counterparty",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimSpan",
                table: "Accounts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimSpan",
                table: "Accounts");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeSpan",
                table: "Counterparty",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
