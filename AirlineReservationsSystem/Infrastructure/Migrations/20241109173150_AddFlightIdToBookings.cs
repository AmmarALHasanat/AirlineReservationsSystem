using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightIdToBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
