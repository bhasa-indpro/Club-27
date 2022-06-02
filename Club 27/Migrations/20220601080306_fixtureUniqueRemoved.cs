using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class fixtureUniqueRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueID_ActivityID_Fixture_Start_End",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Fixture",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueID_ActivityID_Start_End",
                table: "Bookings",
                columns: new[] { "VenueID", "ActivityID", "Start", "End" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueID_ActivityID_Start_End",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Fixture",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueID_ActivityID_Fixture_Start_End",
                table: "Bookings",
                columns: new[] { "VenueID", "ActivityID", "Fixture", "Start", "End" },
                unique: true,
                filter: "[Fixture] IS NOT NULL");
        }
    }
}
