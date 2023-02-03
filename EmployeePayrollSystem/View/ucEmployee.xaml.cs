using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for ucEmployee.xaml
    /// </summary>
    public partial class ucEmployee : UserControl
    {
       private EmployeeViewModel _viewModel;
        private readonly ICategoryService _serviceCat;
        private readonly IDepartmentService _serviceDept;
        public ucEmployee()
        {
            _viewModel = new EmployeeViewModel();
            _serviceCat = new CategoryService();
            _serviceDept = new DepartmentService();
            DataContext = _viewModel;
            InitializeComponent();
            
        }

        

        private void btnClickPassport(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images files|*.JPG;*.JPEG;*.PNG";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == true)
            {
                imagePicture.Source = new BitmapImage(new Uri(dlg.FileName));

                _viewModel.Passport = dlg.FileName;
            }


            //string filename = FileNameTextBox.Text;
            //if (File.Exists(filename))
            //{
            //    // TODO: Show an error message box to user indicating destination file already uploaded
            //    return;
            //}

            //string name = System.IO.Path.GetFileName(filename);
            //string destinationFilename = System.IO.Path.Combine("C:\\temp\\uploaded files\\", name);

            //File.Copy(filename, destinationFilename);

        }

        private void cboCategory_Initialized(object sender, EventArgs e)
        {
            fillCatComboBox();
        }
        async void fillCatComboBox()
        {
            try
            {
                var combodata = await _serviceCat.GetCats();
                if (combodata != null)
                {
                    foreach (var item in combodata)
                    {
                        cboCategory.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        async Task fillDeptComboBox()
        {
            try
            {
                var combodata = await  _serviceDept.GetDepts();
                var data = combodata.Where(x => x.Category.Equals(cboCategory.Text));
                if (data != null)
                {
                    cboDepartment.Items.Clear();
                    foreach (var item in data)
                    {
                        cboDepartment.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cboDepartment_Initialized(object sender, EventArgs e)
        {
            
        }

        private void cboCategory_TouchEnter(object sender, TouchEventArgs e)
        {
            //if (_viewModel.EmpList != null)
            //{
            //    var result = _viewModel.EmpList.FirstOrDefault(x => x.empCode.Equals(cboCategory.Text, StringComparison.OrdinalIgnoreCase));
            //    if (result != null)
            //    {
            //        _viewModel.em = string.Concat(result.empFirstName + " " + result.empLastName);
            //    }
            //    else
            //    {
            //        _viewModel.EmpName = String.Empty;
            //    }
            //}

        }

        private void cboCategory_DropDownClosed(object sender, EventArgs e)
        {
            fillDeptComboBox();
        }
    }
}
