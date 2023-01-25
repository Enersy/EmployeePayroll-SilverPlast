using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_PieceRateAllowances_pieceRateAllowanceId",
                table: "Allowances");

            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_SalaryAllowances_salaryAllowanceId",
                table: "Allowances");

            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_WagersAllowances_wagersAllowanceId",
                table: "Allowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagersAllowances",
                table: "WagersAllowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryAllowances",
                table: "SalaryAllowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceRateAllowances",
                table: "PieceRateAllowances");

            migrationBuilder.RenameTable(
                name: "WagersAllowances",
                newName: "WagersAllowance");

            migrationBuilder.RenameTable(
                name: "SalaryAllowances",
                newName: "SalaryAllowance");

            migrationBuilder.RenameTable(
                name: "PieceRateAllowances",
                newName: "PieceRateAllowance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagersAllowance",
                table: "WagersAllowance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryAllowance",
                table: "SalaryAllowance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceRateAllowance",
                table: "PieceRateAllowance",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PieceRateeSalaryDetails",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<int>(type: "int", nullable: false),
                    empSalaryWeek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empSalaryYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empSalaryPaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empDept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empBasic = table.Column<double>(type: "float", nullable: false),
                    empTA = table.Column<double>(type: "float", nullable: false),
                    empHRA = table.Column<double>(type: "float", nullable: false),
                    empUtilityA = table.Column<double>(type: "float", nullable: false),
                    empMA = table.Column<double>(type: "float", nullable: false),
                    empBonus = table.Column<double>(type: "float", nullable: false),
                    empTax = table.Column<double>(type: "float", nullable: false),
                    empGross = table.Column<double>(type: "float", nullable: false),
                    empTotalSalary = table.Column<double>(type: "float", nullable: false),
                    empOverTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceRateeSalaryDetails", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryeSalaryDetails",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<int>(type: "int", nullable: false),
                    empSalaryMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empSalaryYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empSalaryPaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empDept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empBasic = table.Column<double>(type: "float", nullable: false),
                    empTA = table.Column<double>(type: "float", nullable: false),
                    empHRA = table.Column<double>(type: "float", nullable: false),
                    empUtilityA = table.Column<double>(type: "float", nullable: false),
                    empMA = table.Column<double>(type: "float", nullable: false),
                    empBonus = table.Column<double>(type: "float", nullable: false),
                    empTax = table.Column<double>(type: "float", nullable: false),
                    empGross = table.Column<double>(type: "float", nullable: false),
                    empTotalSalary = table.Column<double>(type: "float", nullable: false),
                    empOverTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryeSalaryDetails", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "WagerseSalaryDetails",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<int>(type: "int", nullable: false),
                    empSalaryWeek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empSalaryYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empSalaryPaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empDept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empBasic = table.Column<double>(type: "float", nullable: false),
                    empTA = table.Column<double>(type: "float", nullable: false),
                    empHRA = table.Column<double>(type: "float", nullable: false),
                    empUtilityA = table.Column<double>(type: "float", nullable: false),
                    empMA = table.Column<double>(type: "float", nullable: false),
                    empBonus = table.Column<double>(type: "float", nullable: false),
                    empTax = table.Column<double>(type: "float", nullable: false),
                    empGross = table.Column<double>(type: "float", nullable: false),
                    empTotalSalary = table.Column<double>(type: "float", nullable: false),
                    empOverTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagerseSalaryDetails", x => x.TransactionId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_PieceRateAllowance_pieceRateAllowanceId",
                table: "Allowances",
                column: "pieceRateAllowanceId",
                principalTable: "PieceRateAllowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_SalaryAllowance_salaryAllowanceId",
                table: "Allowances",
                column: "salaryAllowanceId",
                principalTable: "SalaryAllowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_WagersAllowance_wagersAllowanceId",
                table: "Allowances",
                column: "wagersAllowanceId",
                principalTable: "WagersAllowance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_PieceRateAllowance_pieceRateAllowanceId",
                table: "Allowances");

            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_SalaryAllowance_salaryAllowanceId",
                table: "Allowances");

            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_WagersAllowance_wagersAllowanceId",
                table: "Allowances");

            migrationBuilder.DropTable(
                name: "PieceRateeSalaryDetails");

            migrationBuilder.DropTable(
                name: "SalaryeSalaryDetails");

            migrationBuilder.DropTable(
                name: "WagerseSalaryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagersAllowance",
                table: "WagersAllowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryAllowance",
                table: "SalaryAllowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceRateAllowance",
                table: "PieceRateAllowance");

            migrationBuilder.RenameTable(
                name: "WagersAllowance",
                newName: "WagersAllowances");

            migrationBuilder.RenameTable(
                name: "SalaryAllowance",
                newName: "SalaryAllowances");

            migrationBuilder.RenameTable(
                name: "PieceRateAllowance",
                newName: "PieceRateAllowances");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagersAllowances",
                table: "WagersAllowances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryAllowances",
                table: "SalaryAllowances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceRateAllowances",
                table: "PieceRateAllowances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_PieceRateAllowances_pieceRateAllowanceId",
                table: "Allowances",
                column: "pieceRateAllowanceId",
                principalTable: "PieceRateAllowances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_SalaryAllowances_salaryAllowanceId",
                table: "Allowances",
                column: "salaryAllowanceId",
                principalTable: "SalaryAllowances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_WagersAllowances_wagersAllowanceId",
                table: "Allowances",
                column: "wagersAllowanceId",
                principalTable: "WagersAllowances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
