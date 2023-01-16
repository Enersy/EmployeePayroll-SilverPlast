using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empJob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
