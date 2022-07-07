using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_The_Rise_Of_The_Aid.Migrations
{
    public partial class changedmembernamecollum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "member",
                newName: "RegisteredDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisteredDate",
                table: "member",
                newName: "DateTime");
        }
    }
}
