using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resolutions.Server.Migrations
{
    /// <inheritdoc />
    public partial class ConstantsSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConfigurationConstants",
                columns: new[] { "Name", "Value" },
                values: new object[,]
                {
                    { "MaxEventTypesPerResolution", 3 },
                    { "MaxResolutionsPerUser", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConfigurationConstants",
                keyColumn: "Name",
                keyValue: "MaxEventTypesPerResolution");

            migrationBuilder.DeleteData(
                table: "ConfigurationConstants",
                keyColumn: "Name",
                keyValue: "MaxResolutionsPerUser");
        }
    }
}
