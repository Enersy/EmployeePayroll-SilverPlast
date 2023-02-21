using EmployeePayroll.DataAccess.Implementation;
using EmployeePayroll.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using EmployeePayroll.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<EmployeePayrollDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("Connection")
));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
