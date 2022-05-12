using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class FixtureAndUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Teams_TeamID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Venues_ActivityID",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Enrollments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Fixture",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_ActivityID",
                table: "Venues",
                column: "ActivityID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams",
                column: "ActivityID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedOn",
                table: "Bookings",
                column: "BookedOn",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Teams_TeamID",
                table: "Enrollments",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Teams_TeamID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Venues_ActivityID",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookedOn",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Fixture",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_ActivityID",
                table: "Venues",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams",
                column: "ActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Teams_TeamID",
                table: "Enrollments",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
