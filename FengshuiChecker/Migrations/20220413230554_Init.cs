using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FengshuiChecker.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneNetworkProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNetworkProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberPrefixes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNetworkProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberPrefixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberPrefixes_PhoneNetworkProviders_PhoneNetworkProviderId",
                        column: x => x.PhoneNetworkProviderId,
                        principalTable: "PhoneNetworkProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberPrefixId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneNumberPrefixes_PhoneNumberPrefixId",
                        column: x => x.PhoneNumberPrefixId,
                        principalTable: "PhoneNumberPrefixes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberPrefixes_PhoneNetworkProviderId",
                table: "PhoneNumberPrefixes",
                column: "PhoneNetworkProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneNumberPrefixId",
                table: "PhoneNumbers",
                column: "PhoneNumberPrefixId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "PhoneNumberPrefixes");

            migrationBuilder.DropTable(
                name: "PhoneNetworkProviders");
        }
    }
}
