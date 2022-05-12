using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class TeamUniqueChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name_ActivityID",
                table: "Teams",
                columns: new[] { "Name", "ActivityID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Name_ActivityID",
                table: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ActivityID",
                table: "Teams",
                column: "ActivityID",
                unique: true);
        }
    }
}
