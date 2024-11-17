using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class fix_boooking_realtion_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightSeats_Bookings_BookingId",
                table: "FlightSeats");

            migrationBuilder.DropIndex(
                name: "IX_FlightSeats_BookingId",
                table: "FlightSeats");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "FlightSeats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "FlightSeats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_BookingId",
                table: "FlightSeats",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightSeats_Bookings_BookingId",
                table: "FlightSeats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }
    }
}
