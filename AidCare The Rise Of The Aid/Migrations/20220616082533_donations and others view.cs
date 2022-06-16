using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_The_Rise_Of_The_Aid.Migrations
{
    public partial class donationsandothersview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donation_member_memberId",
                table: "donation");

            migrationBuilder.DropIndex(
                name: "IX_donation_memberId",
                table: "donation");

            migrationBuilder.DropColumn(
                name: "memberId",
                table: "donation");

            migrationBuilder.AddColumn<int>(
                name: "DonationId",
                table: "member",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_member_DonationId",
                table: "member",
                column: "DonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_member_donation_DonationId",
                table: "member",
                column: "DonationId",
                principalTable: "donation",
                principalColumn: "DonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_donation_DonationId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_DonationId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "DonationId",
                table: "member");

            migrationBuilder.AddColumn<int>(
                name: "memberId",
                table: "donation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_donation_memberId",
                table: "donation",
                column: "memberId");

            migrationBuilder.AddForeignKey(
                name: "FK_donation_member_memberId",
                table: "donation",
                column: "memberId",
                principalTable: "member",
                principalColumn: "memberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
