using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initials2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HourlyRate",
                table: "salaryMatrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "SalaryeSalaryDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "salaryMatrices");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeName",
                table: "SalaryeSalaryDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
