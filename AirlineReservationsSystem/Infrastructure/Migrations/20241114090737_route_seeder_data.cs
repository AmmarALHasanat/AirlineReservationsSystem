using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class route_seeder_data : Migration
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
                    { 2, "AMM", "4h 0m", "AQJ" },
                    { 3, "AUH", "3h 15m", "AMM" },
                    { 4, "AMM", "3h 15m", "AUH" },
                    { 5, "DXB", "3h 30m", "AMM" },
                    { 6, "AMM", "3h 30m", "DXB" },
                    { 7, "SHJ", "3h 40m", "AMM" },
                    { 8, "AMM", "3h 40m", "SHJ" },
                    { 9, "RKT", "1h 30m", "AMM" },
                    { 10, "AMM", "1h 30m", "RKT" },
                    { 11, "AAN", "2h 0m", "AMM" },
                    { 12, "AMM", "2h 0m", "AAN" },
                    { 13, "RUH", "3h 10m", "AMM" },
                    { 14, "AMM", "3h 10m", "RUH" },
                    { 15, "JED", "2h 50m", "AMM" },
                    { 16, "AMM", "2h 50m", "JED" },
                    { 17, "DMM", "3h 5m", "AMM" },
                    { 18, "AMM", "3h 5m", "DMM" },
                    { 19, "AHB", "3h 20m", "AMM" },
                    { 20, "AMM", "3h 20m", "AHB" },
                    { 21, "CAI", "1h 45m", "AMM" },
                    { 22, "AMM", "1h 45m", "CAI" },
                    { 23, "SSH", "3h 10m", "AMM" },
                    { 24, "AMM", "3h 10m", "SSH" },
                    { 25, "IST", "2h 45m", "AMM" },
                    { 26, "AMM", "2h 45m", "IST" },
                    { 27, "ESB", "4h 10m", "AMM" },
                    { 28, "AMM", "4h 10m", "ESB" },
                    { 29, "TZX", "2h 55m", "AMM" },
                    { 30, "AMM", "2h 55m", "TZX" },
                    { 31, "RUH", "2h 45m", "AUH" },
                    { 32, "AUH", "2h 45m", "RUH" },
                    { 33, "JED", "2h 20m", "AUH" },
                    { 34, "AUH", "2h 20m", "JED" },
                    { 35, "DMM", "2h 30m", "AUH" },
                    { 36, "AUH", "2h 30m", "DMM" },
                    { 37, "AHB", "2h 50m", "AUH" },
                    { 38, "AUH", "2h 50m", "AHB" },
                    { 39, "CAI", "3h 10m", "AUH" },
                    { 40, "AUH", "3h 10m", "CAI" },
                    { 41, "SSH", "3h 0m", "AUH" },
                    { 42, "AUH", "3h 0m", "SSH" },
                    { 43, "IST", "3h 30m", "AUH" },
                    { 44, "AUH", "3h 30m", "IST" },
                    { 45, "ESB", "4h 0m", "AUH" },
                    { 46, "AUH", "4h 0m", "ESB" },
                    { 47, "TZX", "3h 40m", "AUH" },
                    { 48, "AUH", "3h 40m", "TZX" },
                    { 49, "RUH", "2h 55m", "DXB" },
                    { 50, "DXB", "2h 55m", "RUH" },
                    { 51, "JED", "2h 25m", "DXB" },
                    { 52, "DXB", "2h 25m", "JED" },
                    { 53, "DMM", "2h 35m", "DXB" },
                    { 54, "DXB", "2h 35m", "DMM" },
                    { 55, "AHB", "3h 10m", "DXB" },
                    { 56, "DXB", "3h 10m", "AHB" },
                    { 57, "CAI", "3h 0m", "DXB" },
                    { 58, "DXB", "3h 0m", "CAI" },
                    { 59, "SSH", "3h 15m", "DXB" },
                    { 60, "DXB", "3h 15m", "SSH" },
                    { 61, "IST", "3h 10m", "DXB" },
                    { 62, "DXB", "3h 10m", "IST" },
                    { 63, "ESB", "4h 0m", "DXB" },
                    { 64, "DXB", "4h 0m", "ESB" },
                    { 65, "TZX", "3h 25m", "DXB" },
                    { 66, "DXB", "3h 25m", "TZX" },
                    { 67, "CAI", "3h 0m", "RUH" },
                    { 68, "RUH", "3h 0m", "CAI" },
                    { 69, "SSH", "3h 30m", "RUH" },
                    { 70, "RUH", "3h 30m", "SSH" },
                    { 71, "IST", "3h 0m", "RUH" },
                    { 72, "RUH", "3h 0m", "IST" },
                    { 73, "ESB", "3h 15m", "RUH" },
                    { 74, "RUH", "3h 15m", "ESB" },
                    { 75, "TZX", "3h 10m", "RUH" },
                    { 76, "RUH", "3h 10m", "TZX" },
                    { 77, "ESB", "1h 40m", "IST" },
                    { 78, "IST", "1h 40m", "ESB" },
                    { 79, "TZX", "1h 30m", "IST" },
                    { 80, "IST", "1h 30m", "TZX" },
                    { 81, "TZX", "1h 20m", "ESB" },
                    { 82, "ESB", "1h 20m", "TZX" }
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

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "TravelRouteId",
                keyValue: 82);
        }
    }
}
