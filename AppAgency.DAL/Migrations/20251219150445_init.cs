using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppAgency.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "date", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.CheckConstraint("CK_Booking_Date", "[BookingDate] >= GetDate()");
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.CheckConstraint("CK_Activity__Price", "[price] > 0");
                    table.ForeignKey(
                        name: "FK_Activities_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityBooked",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityBooked", x => new { x.BookId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_ActivityBooked_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityBooked_Bookings_BookId",
                        column: x => x.BookId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "ClientName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Cypher" },
                    { 2, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dipper Pines" },
                    { 3, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mabel Pines" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "City", "Country", "Description" },
                values: new object[,]
                {
                    { 1, "Bruxelles", "Belgique", "Washington d'Europe" },
                    { 2, "Paris", "France", "Ville lumière" },
                    { 3, "Barcelone", "Espagne", "Ville de Gaudi" },
                    { 4, "Londres", "Royaume-Uni", "Ville-monde" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "DestinationId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Découvre les monuments les plus célèbres sur visible depuis le bord de la Seine...", 2, 45m, "Visite de Paris en Bateau la nuit" },
                    { 2, "Découvre les monuments tranquillement depuis nos bus a deux étages...", 2, 35m, "Visite de Paris en Bus" },
                    { 3, "Avec notre guide découvrez l'histoire de cette villes...", 1, 60m, "Visite de Bruxelles" }
                });

            migrationBuilder.InsertData(
                table: "ActivityBooked",
                columns: new[] { "ActivityId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DestinationId",
                table: "Activities",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBooked_ActivityId",
                table: "ActivityBooked",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_City_Country",
                table: "Destinations",
                columns: new[] { "City", "Country" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityBooked");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
