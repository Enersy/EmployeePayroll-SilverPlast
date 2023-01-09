﻿using EmployeePayroll.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess.Context
{
    public class EmployeePayrollDbContext:DbContext
    {
        public EmployeePayrollDbContext(DbContextOptions<EmployeePayrollDbContext> options) : base(options)
        {

        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PieceRateAllowance> PieceRateAllowances { get; set; }
        public DbSet<WagersAllowance> WagersAllowances { get; set; }
        public DbSet<SalaryAllowance> SalaryAllowances { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SalaryMatrix> salaryMatrices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       

    }
}
