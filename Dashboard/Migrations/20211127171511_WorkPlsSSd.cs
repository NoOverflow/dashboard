using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    public partial class WorkPlsSSd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
