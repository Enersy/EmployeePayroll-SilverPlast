﻿// <auto-generated />
using System;
using EmployeePayroll.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeePayroll.DataAccess.Migrations
{
    [DbContext(typeof(EmployeePayrollDbContext))]
    partial class EmployeePayrollDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Allowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("pieceRateAllowanceId")
                        .HasColumnType("int");

                    b.Property<int>("salaryAllowanceId")
                        .HasColumnType("int");

                    b.Property<int>("wagersAllowanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pieceRateAllowanceId");

                    b.HasIndex("salaryAllowanceId");

                    b.HasIndex("wagersAllowanceId");

                    b.ToTable("Allowances");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("empDob")
                        .HasColumnType("datetime2");

                    b.Property<string>("empFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("empJob")
                        .HasColumnType("datetime2");

                    b.Property<string>("empLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nextOfKin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Grade", b =>
                {
                    b.Property<int>("gradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("gradeId"));

                    b.Property<double>("gradeBonus")
                        .HasColumnType("float");

                    b.Property<double>("gradeHRA")
                        .HasColumnType("float");

                    b.Property<double>("gradeMA")
                        .HasColumnType("float");

                    b.Property<string>("gradeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gradeShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("gradeTA")
                        .HasColumnType("float");

                    b.Property<double>("grade_basic")
                        .HasColumnType("float");

                    b.HasKey("gradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<double>("LoanBalance")
                        .HasColumnType("float");

                    b.Property<double>("RepaymentAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.PieceRateAllowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("PieceRateHouseAllowance")
                        .HasColumnType("float");

                    b.Property<double>("PieceRateMedAllowance")
                        .HasColumnType("float");

                    b.Property<double>("PieceRateMiscelenousAllowance")
                        .HasColumnType("float");

                    b.Property<double>("PieceRateNightAllowance")
                        .HasColumnType("float");

                    b.Property<double>("PieceRateOvertimeAllowance")
                        .HasColumnType("float");

                    b.Property<double>("PieceRateSpecialAllowance")
                        .HasColumnType("float");

                    b.Property<double>("PieceRateTraFedAllowance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PieceRateAllowances");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.SalaryAllowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("SalaryHouseAllowance")
                        .HasColumnType("float");

                    b.Property<double>("SalaryMedAllowance")
                        .HasColumnType("float");

                    b.Property<double>("SalaryMiscelenousAllowance")
                        .HasColumnType("float");

                    b.Property<double>("SalaryOvertimeAllowance")
                        .HasColumnType("float");

                    b.Property<double>("SalarySpecialAllowance")
                        .HasColumnType("float");

                    b.Property<double>("SalaryTraFedAllowance")
                        .HasColumnType("float");

                    b.Property<double>("SalaryUtilityAllowance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SalaryAllowances");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.SalaryMatrix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BigMatRate")
                        .HasColumnType("float");

                    b.Property<double>("CashAdvance")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DayRate")
                        .HasColumnType("float");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HouseAllowanceRate")
                        .HasColumnType("float");

                    b.Property<double>("NightAllowanceRate")
                        .HasColumnType("float");

                    b.Property<double>("SmallMatRate")
                        .HasColumnType("float");

                    b.Property<double>("TPFeedingAllowanceRate")
                        .HasColumnType("float");

                    b.Property<double>("UtilityAllowanceRate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("salaryMatrices");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usertype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.WagersAllowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("WagersHouseAllowance")
                        .HasColumnType("float");

                    b.Property<double>("WagersMedAllowance")
                        .HasColumnType("float");

                    b.Property<double>("WagersMiscelenousAllowance")
                        .HasColumnType("float");

                    b.Property<double>("WagersNightAllowance")
                        .HasColumnType("float");

                    b.Property<double>("WagersOvertimeAllowance")
                        .HasColumnType("float");

                    b.Property<double>("WagersSpecialAllowance")
                        .HasColumnType("float");

                    b.Property<double>("WagersTraFedAllowance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("WagersAllowances");
                });

            modelBuilder.Entity("EmployeePayroll.Domain.Entities.Allowance", b =>
                {
                    b.HasOne("EmployeePayroll.Domain.Entities.PieceRateAllowance", "pieceRateAllowance")
                        .WithMany()
                        .HasForeignKey("pieceRateAllowanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayroll.Domain.Entities.SalaryAllowance", "salaryAllowance")
                        .WithMany()
                        .HasForeignKey("salaryAllowanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayroll.Domain.Entities.WagersAllowance", "wagersAllowance")
                        .WithMany()
                        .HasForeignKey("wagersAllowanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pieceRateAllowance");

                    b.Navigation("salaryAllowance");

                    b.Navigation("wagersAllowance");
                });
#pragma warning restore 612, 618
        }
    }
}
