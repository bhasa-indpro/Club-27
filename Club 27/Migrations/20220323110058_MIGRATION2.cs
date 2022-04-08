using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class MIGRATION2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_EmployeeID",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EmployeeID_ActivityID",
                table: "Enrollments",
                columns: new[] { "EmployeeID", "ActivityID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                principalTable: "EmployeeMasters",
                principalColumn: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_EmployeeID_ActivityID",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EmployeeID",
                table: "Enrollments",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                principalTable: "EmployeeMasters",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
