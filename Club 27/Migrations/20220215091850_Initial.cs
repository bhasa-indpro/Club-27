using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_27.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityMasters",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMasters", x => x.ActivityID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMasters",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMasters", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_ActivityMasters_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "ActivityMasters",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_EmployeeMasters_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeMasters",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_EmployeeMasters_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeMasters",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ActivityID",
                table: "Enrollments",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EmployeeID",
                table: "Enrollments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ActivityMasters");

            migrationBuilder.DropTable(
                name: "EmployeeMasters");
        }
    }
}
