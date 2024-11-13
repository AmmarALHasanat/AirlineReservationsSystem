using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class add_travel_route_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "TravelRouteId", "Destination", "EstimatedTime", "Origin" },
                values: new object[,]
                {
                    { 1, "AQJ", "4h 0m", "AMM" },
                    { 2, "DXB", "3h 45m", "AMM" },
                    { 3, "RUH", "2h 0m", "AMM" },
                    { 4, "DXB", "2h 30m", "AQJ" },
                    { 5, "DXB", "1h 10m", "AUH" },
                    { 6, "SHJ", "1h 0m", "AUH" },
                    { 7, "SHJ", "1h 0m", "DXB" },
                    { 8, "RUH", "1h 50m", "DXB" },
                    { 9, "AUH", "1h 30m", "AAN" },
                    { 10, "JED", "1h 15m", "RUH" },
                    { 11, "DMM", "1h 40m", "RUH" },
                    { 12, "MED", "1h 30m", "RUH" },
                    { 13, "AHB", "1h 40m", "RUH" },
                    { 14, "TIF", "1h 25m", "RUH" },
                    { 15, "HBE", "1h 0m", "CAI" },
                    { 16, "SSH", "1h 30m", "CAI" },
                    { 17, "LXR", "1h 0m", "CAI" },
                    { 18, "HRG", "1h 10m", "CAI" },
                    { 19, "ASW", "1h 20m", "CAI" },
                    { 20, "ESB", "1h 15m", "IST" },
                    { 21, "ADB", "1h 10m", "IST" },
                    { 22, "AYT", "1h 25m", "IST" },
                    { 23, "BJV", "1h 15m", "IST" },
                    { 24, "TZX", "1h 30m", "IST" },
                    { 25, "DXB", "1h 30m", "KWI" },
                    { 26, "RUH", "1h 30m", "KWI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 26);
        }
    }
}
