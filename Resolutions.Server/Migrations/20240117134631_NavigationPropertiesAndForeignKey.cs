using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resolutions.Server.Migrations
{
    /// <inheritdoc />
    public partial class NavigationPropertiesAndForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Resolutions");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Resolutions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_AppUserId",
                table: "Resolutions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resolutions_AspNetUsers_AppUserId",
                table: "Resolutions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resolutions_AspNetUsers_AppUserId",
                table: "Resolutions");

            migrationBuilder.DropIndex(
                name: "IX_Resolutions_AppUserId",
                table: "Resolutions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Resolutions");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Resolutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
