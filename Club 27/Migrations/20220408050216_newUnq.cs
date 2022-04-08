using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class newUnq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmployeeMasters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityName",
                table: "ActivityMasters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMasters_Email",
                table: "EmployeeMasters",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMasters_ActivityName",
                table: "ActivityMasters",
                column: "ActivityName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeMasters_Email",
                table: "EmployeeMasters");

            migrationBuilder.DropIndex(
                name: "IX_ActivityMasters_ActivityName",
                table: "ActivityMasters");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityName",
                table: "ActivityMasters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
