using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class spellingError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ActivityMasters_ActvityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ActvityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookedOn",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ActvityID",
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
                name: "IX_Bookings_ActivityID",
                table: "Bookings",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedOn_VenueID_ActivityID_Fixture",
                table: "Bookings",
                columns: new[] { "BookedOn", "VenueID", "ActivityID", "Fixture" },
                unique: true,
                filter: "[Fixture] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ActivityMasters_ActivityID",
                table: "Bookings",
                column: "ActivityID",
                principalTable: "ActivityMasters",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ActivityMasters_ActivityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ActivityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookedOn_VenueID_ActivityID_Fixture",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Fixture",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActvityID",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ActvityID",
                table: "Bookings",
                column: "ActvityID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedOn",
                table: "Bookings",
                column: "BookedOn",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ActivityMasters_ActvityID",
                table: "Bookings",
                column: "ActvityID",
                principalTable: "ActivityMasters",
                principalColumn: "ActivityID");
        }
    }
}
