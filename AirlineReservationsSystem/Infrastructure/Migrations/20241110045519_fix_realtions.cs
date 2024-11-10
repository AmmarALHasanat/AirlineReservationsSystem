using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class fix_realtions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Seats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "FlightSeats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FlightSeats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_BookingId",
                table: "FlightSeats",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_UserId",
                table: "FlightSeats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightSeats_AspNetUsers_UserId",
                table: "FlightSeats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightSeats_Bookings_BookingId",
                table: "FlightSeats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightSeats_AspNetUsers_UserId",
                table: "FlightSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightSeats_Bookings_BookingId",
                table: "FlightSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_FlightSeats_BookingId",
                table: "FlightSeats");

            migrationBuilder.DropIndex(
                name: "IX_FlightSeats_UserId",
                table: "FlightSeats");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "FlightSeats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlightSeats");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
