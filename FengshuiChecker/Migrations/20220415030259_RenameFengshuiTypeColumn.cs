using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FengshuiChecker.Migrations
{
    public partial class RenameFengshuiTypeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFengshuiPrefix",
                table: "PhoneNumberPrefixes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFengshuiPrefix",
                table: "PhoneNumberPrefixes");
        }
    }
}
