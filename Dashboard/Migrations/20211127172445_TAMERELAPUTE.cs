using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    public partial class TAMERELAPUTE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OAuthSession_AspNetUsers_DashboardUserId1",
                table: "OAuthSession");

            migrationBuilder.DropIndex(
                name: "IX_OAuthSession_DashboardUserId1",
                table: "OAuthSession");

            migrationBuilder.DropColumn(
                name: "DashboardUserId1",
                table: "OAuthSession");

            migrationBuilder.AddColumn<string>(
                name: "TAMERELAPUTE",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TAMERELAPUTE",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DashboardUserId1",
                table: "OAuthSession",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OAuthSession_DashboardUserId1",
                table: "OAuthSession",
                column: "DashboardUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OAuthSession_AspNetUsers_DashboardUserId1",
                table: "OAuthSession",
                column: "DashboardUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
