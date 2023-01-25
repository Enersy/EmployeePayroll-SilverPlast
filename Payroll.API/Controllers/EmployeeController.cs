using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _unitOfWork.Employee.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return (Employee)await _unitOfWork.Employee.Find(x => x.empId == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] Employee employee)
        {
            await _unitOfWork.Employee.Add(employee);
            _unitOfWork.Save();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Employee employee)
        {
            await _unitOfWork.Employee.UpdateEmployee(employee);
            _unitOfWork.Save();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _unitOfWork.Employee.DeleteEmployee(id);
            _unitOfWork.Save();
        }
    }
}
