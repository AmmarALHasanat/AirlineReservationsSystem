using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationsSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightSeats_AspNetUsers_UserId",
                table: "FlightSeats");

            migrationBuilder.DropIndex(
                name: "IX_FlightSeats_UserId",
                table: "FlightSeats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlightSeats");

            migrationBuilder.AlterColumn<string>(
                name: "EstimatedTime",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EstimatedTime",
                table: "Routes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FlightSeats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
