using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    gradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gradeShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gradebasic = table.Column<double>(name: "grade_basic", type: "float", nullable: false),
                    gradeTA = table.Column<double>(type: "float", nullable: false),
                    gradeHRA = table.Column<double>(type: "float", nullable: false),
                    gradeMA = table.Column<double>(type: "float", nullable: false),
                    gradeBonus = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.gradeId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    RepaymentAmount = table.Column<double>(type: "float", nullable: false),
                    LoanBalance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PieceRateAllowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceRateTraFedAllowance = table.Column<double>(type: "float", nullable: false),
                    PieceRateHouseAllowance = table.Column<double>(type: "float", nullable: false),
                    PieceRateOvertimeAllowance = table.Column<double>(type: "float", nullable: false),
                    PieceRateMiscelenousAllowance = table.Column<double>(type: "float", nullable: false),
                    PieceRateMedAllowance = table.Column<double>(type: "float", nullable: false),
                    PieceRateSpecialAllowance = table.Column<double>(type: "float", nullable: false),
                    PieceRateNightAllowance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceRateAllowances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAllowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryMedAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryTraFedAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryHouseAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryUtilityAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryOvertimeAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryMiscelenousAllowance = table.Column<double>(type: "float", nullable: false),
                    SalarySpecialAllowance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAllowances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usertype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WagersAllowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WagersTraFedAllowance = table.Column<double>(type: "float", nullable: false),
                    WagersHouseAllowance = table.Column<double>(type: "float", nullable: false),
                    WagersOvertimeAllowance = table.Column<double>(type: "float", nullable: false),
                    WagersMiscelenousAllowance = table.Column<double>(type: "float", nullable: false),
                    WagersMedAllowance = table.Column<double>(type: "float", nullable: false),
                    WagersSpecialAllowance = table.Column<double>(type: "float", nullable: false),
                    WagersNightAllowance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagersAllowances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salaryAllowanceId = table.Column<int>(type: "int", nullable: false),
                    wagersAllowanceId = table.Column<int>(type: "int", nullable: false),
                    pieceRateAllowanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allowances_PieceRateAllowances_pieceRateAllowanceId",
                        column: x => x.pieceRateAllowanceId,
                        principalTable: "PieceRateAllowances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allowances_SalaryAllowances_salaryAllowanceId",
                        column: x => x.salaryAllowanceId,
                        principalTable: "SalaryAllowances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allowances_WagersAllowances_wagersAllowanceId",
                        column: x => x.wagersAllowanceId,
                        principalTable: "WagersAllowances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_pieceRateAllowanceId",
                table: "Allowances",
                column: "pieceRateAllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_salaryAllowanceId",
                table: "Allowances",
                column: "salaryAllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_wagersAllowanceId",
                table: "Allowances",
                column: "wagersAllowanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowances");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PieceRateAllowances");

            migrationBuilder.DropTable(
                name: "SalaryAllowances");

            migrationBuilder.DropTable(
                name: "WagersAllowances");
        }
    }
}
