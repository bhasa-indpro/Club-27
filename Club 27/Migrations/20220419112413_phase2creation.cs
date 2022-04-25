using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class phase2creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Venues_ActivityMasters_ActivityID",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "Venues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VenueID",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "EmployeeMasters",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueID",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_VenueID",
                table: "Enrollments",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMasters_RoleID",
                table: "EmployeeMasters",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueID",
                table: "Bookings",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "VenueID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMasters_Role_RoleID",
                table: "EmployeeMasters",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Venues_VenueID",
                table: "Enrollments",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "VenueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                principalTable: "EmployeeMasters",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_ActivityMasters_ActivityID",
                table: "Venues",
                column: "ActivityID",
                principalTable: "ActivityMasters",
                principalColumn: "ActivityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMasters_Role_RoleID",
                table: "EmployeeMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Venues_VenueID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Venues_ActivityMasters_ActivityID",
                table: "Venues");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_VenueID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMasters_RoleID",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VenueID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "EmployeeMasters");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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

            migrationBuilder.AlterColumn<int>(
                name: "VenueID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueID",
                table: "Bookings",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "VenueID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployeeMasters_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                principalTable: "EmployeeMasters",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_ActivityMasters_ActivityID",
                table: "Venues",
                column: "ActivityID",
                principalTable: "ActivityMasters",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
