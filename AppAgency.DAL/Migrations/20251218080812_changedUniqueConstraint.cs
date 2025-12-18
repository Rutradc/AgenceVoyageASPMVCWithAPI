using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgency.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changedUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destinations_Country",
                table: "Destinations");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_City",
                table: "Destinations",
                column: "City",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destinations_City",
                table: "Destinations");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_Country",
                table: "Destinations",
                column: "Country",
                unique: true);
        }
    }
}
