using Microsoft.EntityFrameworkCore.Migrations;

namespace APK2.Migrations
{
    public partial class Edete_Entitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                table: "User",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_StatusId",
                table: "Post",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StatusId",
                table: "Employee",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Status_StatusId",
                table: "Employee",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Status_StatusId",
                table: "Post",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Status_StatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Status_StatusId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StatusId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Post_StatusId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Employee_StatusId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Employee");
        }
    }
}
