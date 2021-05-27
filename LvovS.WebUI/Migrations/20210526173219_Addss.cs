using Microsoft.EntityFrameworkCore.Migrations;

namespace LvovS.WebUI.Migrations
{
    public partial class Addss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcountName",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Incidents");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Incidents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AccountId",
                table: "Incidents",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_AspNetUsers_AccountId",
                table: "Incidents",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_AspNetUsers_AccountId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_AccountId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Incidents");

            migrationBuilder.AddColumn<string>(
                name: "AcountName",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
