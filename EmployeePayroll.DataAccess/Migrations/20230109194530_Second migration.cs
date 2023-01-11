using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HouseAllowanceRate",
                table: "salaryMatrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NightAllowanceRate",
                table: "salaryMatrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TPFeedingAllowanceRate",
                table: "salaryMatrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UtilityAllowanceRate",
                table: "salaryMatrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseAllowanceRate",
                table: "salaryMatrices");

            migrationBuilder.DropColumn(
                name: "NightAllowanceRate",
                table: "salaryMatrices");

            migrationBuilder.DropColumn(
                name: "TPFeedingAllowanceRate",
                table: "salaryMatrices");

            migrationBuilder.DropColumn(
                name: "UtilityAllowanceRate",
                table: "salaryMatrices");
        }
    }
}
