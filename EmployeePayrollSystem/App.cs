using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.DataAccess.Implementation;
using EmployeePayroll.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            services.AddSingleton<MainWindow>();
           
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
        }
    }
}
