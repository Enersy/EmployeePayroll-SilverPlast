using EmployeePayroll.DataAccess.Implementation;
using EmployeePayroll.Domain.Repository;
using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.View;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace EmployeePayrollSystem
{
    public partial class App: Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //services.AddHttpClient("", c=>{
            //    c.BaseAddress = new Uri();
            //});
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddSingleton<MainWindow>();
           
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
        }
    }
}
