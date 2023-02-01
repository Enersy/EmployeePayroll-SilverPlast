using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    EmpCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTime = table.Column<double>(type: "float", nullable: false),
                    TotalHrs = table.Column<double>(type: "float", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empJob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empId);
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
                name: "PieceRateAllowance",
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
                    table.PrimaryKey("PK_PieceRateAllowance", x => x.Id);
                });

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
                name: "SalaryAllowance",
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
                    table.PrimaryKey("PK_SalaryAllowance", x => x.Id);
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
                name: "salaryMatrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayRate = table.Column<double>(type: "float", nullable: false),
                    CashAdvance = table.Column<double>(type: "float", nullable: false),
                    SmallMatRate = table.Column<double>(type: "float", nullable: false),
                    BigMatRate = table.Column<double>(type: "float", nullable: false),
                    HouseAllowanceRate = table.Column<double>(type: "float", nullable: false),
                    TPFeedingAllowanceRate = table.Column<double>(type: "float", nullable: false),
                    NightAllowanceRate = table.Column<double>(type: "float", nullable: false),
                    UtilityAllowanceRate = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaryMatrices", x => x.Id);
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
                name: "WagersAllowance",
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
                    table.PrimaryKey("PK_WagersAllowance", x => x.Id);
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
                        name: "FK_Allowances_PieceRateAllowance_pieceRateAllowanceId",
                        column: x => x.pieceRateAllowanceId,
                        principalTable: "PieceRateAllowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allowances_SalaryAllowance_salaryAllowanceId",
                        column: x => x.salaryAllowanceId,
                        principalTable: "SalaryAllowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allowances_WagersAllowance_wagersAllowanceId",
                        column: x => x.wagersAllowanceId,
                        principalTable: "WagersAllowance",
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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "PieceRateeSalaryDetails");

            migrationBuilder.DropTable(
                name: "SalaryeSalaryDetails");

            migrationBuilder.DropTable(
                name: "salaryMatrices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WagerseSalaryDetails");

            migrationBuilder.DropTable(
                name: "PieceRateAllowance");

            migrationBuilder.DropTable(
                name: "SalaryAllowance");

            migrationBuilder.DropTable(
                name: "WagersAllowance");
        }
    }
}
