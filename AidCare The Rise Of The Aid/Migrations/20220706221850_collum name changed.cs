using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_The_Rise_Of_The_Aid.Migrations
{
    public partial class collumnamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "protest");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProtestDate",
                table: "protest",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProtestDate",
                table: "protest");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "protest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
