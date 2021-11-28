using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    public partial class RefactorOAuthCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OAuthSession",
                table: "OAuthSession");

            migrationBuilder.DropColumn(
                name: "SpotifyAccessToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpotifyRefreshToken",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OAuthSession",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OAuthSession",
                table: "OAuthSession",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OAuthSession",
                table: "OAuthSession");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OAuthSession");

            migrationBuilder.AddColumn<string>(
                name: "SpotifyAccessToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpotifyRefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OAuthSession",
                table: "OAuthSession",
                column: "ServiceType");
        }
    }
}
