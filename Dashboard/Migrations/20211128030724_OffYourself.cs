using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    public partial class OffYourself : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OAuthSession_AspNetUsers_DashboardUserId",
                table: "OAuthSession");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OAuthSession",
                newName: "SessionId");

            migrationBuilder.AlterColumn<string>(
                name: "DashboardUserId",
                table: "OAuthSession",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OAuthSession_AspNetUsers_DashboardUserId",
                table: "OAuthSession",
                column: "DashboardUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OAuthSession_AspNetUsers_DashboardUserId",
                table: "OAuthSession");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "OAuthSession",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "DashboardUserId",
                table: "OAuthSession",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_OAuthSession_AspNetUsers_DashboardUserId",
                table: "OAuthSession",
                column: "DashboardUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
