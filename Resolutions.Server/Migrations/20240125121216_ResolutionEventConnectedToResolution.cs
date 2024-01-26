using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resolutions.Server.Migrations
{
    /// <inheritdoc />
    public partial class ResolutionEventConnectedToResolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "EventTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_ResolutionId",
                table: "EventTypes",
                column: "ResolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypes_Resolutions_ResolutionId",
                table: "EventTypes",
                column: "ResolutionId",
                principalTable: "Resolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTypes_Resolutions_ResolutionId",
                table: "EventTypes");

            migrationBuilder.DropIndex(
                name: "IX_EventTypes_ResolutionId",
                table: "EventTypes");

            migrationBuilder.DropColumn(
                name: "ResolutionId",
                table: "EventTypes");
        }
    }
}
