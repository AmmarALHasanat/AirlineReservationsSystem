using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class update_travel_route : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Routes_RouteId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Routes",
                newName: "TravelRouteId");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Flights",
                newName: "TravelRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_RouteId",
                table: "Flights",
                newName: "IX_Flights_TravelRouteId");

            migrationBuilder.AlterColumn<string>(
                name: "Origin",
                table: "Routes",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Routes",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Routes_TravelRouteId",
                table: "Flights",
                column: "TravelRouteId",
                principalTable: "Routes",
                principalColumn: "TravelRouteId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Routes_TravelRouteId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "TravelRouteId",
                table: "Routes",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "TravelRouteId",
                table: "Flights",
                newName: "RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_TravelRouteId",
                table: "Flights",
                newName: "IX_Flights_RouteId");

            migrationBuilder.AlterColumn<string>(
                name: "Origin",
                table: "Routes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Routes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Routes_RouteId",
                table: "Flights",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
