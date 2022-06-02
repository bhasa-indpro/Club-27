using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class BookingStartEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookedOn_VenueID_ActivityID_Fixture",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "BookedOn",
                table: "Bookings",
                newName: "Start");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueID_ActivityID_Fixture_Start_End",
                table: "Bookings",
                columns: new[] { "VenueID", "ActivityID", "Fixture", "Start", "End" },
                unique: true,
                filter: "[Fixture] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueID_ActivityID_Fixture_Start_End",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Bookings",
                newName: "BookedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedOn_VenueID_ActivityID_Fixture",
                table: "Bookings",
                columns: new[] { "BookedOn", "VenueID", "ActivityID", "Fixture" },
                unique: true,
                filter: "[Fixture] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueID",
                table: "Bookings",
                column: "VenueID");
        }
    }
}
