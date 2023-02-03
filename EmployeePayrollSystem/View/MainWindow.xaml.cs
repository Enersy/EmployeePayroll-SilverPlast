﻿
using EmployeePayroll.Domain.Repository;
using EmployeePayrollSystem;
using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.View;
using EmployeePayrollSystem.ViewModels;
using System;
using System.Windows;


namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IDepartmentService departmentService;
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        private void BtnClickDepartment(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucDepartment();
        }

        private void BtnClickCategory(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucCategory();
        }

        private void BtnClickMatrix(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucSalaryMatrix();
        }

        private void BtnClickEmpManager(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucEmployeeManager();
        }

        private void BtnClickEmpRegistration(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucRegisterEmployee();
        }

        private void BtnClickLoanApplication(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClickEmpLoanManager(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClickEmpAttendance(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucEmployeeAttendance();
        }

        private void btnSalaryManager(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucSalary();
        }

        private void btnLoanClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoan_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.Content = new ucLoanRegistration();
        }
    }
}
