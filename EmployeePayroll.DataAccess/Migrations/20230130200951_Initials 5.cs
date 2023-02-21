using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initials5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashAdvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCollected = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvanceAmount = table.Column<double>(type: "float", nullable: false),
                    NoOfInstallment = table.Column<int>(type: "int", nullable: false),
                    InstallmentAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAdvances", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashAdvances");
        }
    }
}
