using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APK2.Migrations
{
    public partial class Insert_Invose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatesNDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Caption = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatesNDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatesNDs_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    RegistrNumber = table.Column<int>(type: "int", nullable: false),
                    RegistrDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumberInvoce = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateInvoce = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    NoteInvoce = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RatesNDSId = table.Column<int>(type: "int", nullable: true),
                    AmountNDS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateTimeCreat = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserCreatId = table.Column<int>(type: "int", nullable: true),
                    LastChange = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoces_Counterparty_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoces_RatesNDs_RatesNDSId",
                        column: x => x.RatesNDSId,
                        principalTable: "RatesNDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoces_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoces_User_UserCreatId",
                        column: x => x.UserCreatId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Invoces_CounterpartyId",
                table: "Invoces",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoces_RatesNDSId",
                table: "Invoces",
                column: "RatesNDSId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoces_StatusId",
                table: "Invoces",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoces_UserCreatId",
                table: "Invoces",
                column: "UserCreatId");

            migrationBuilder.CreateIndex(
                name: "IX_RatesNDs_StatusId",
                table: "RatesNDs",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoces");

            migrationBuilder.DropTable(
                name: "RatesNDs");
        }
    }
}
