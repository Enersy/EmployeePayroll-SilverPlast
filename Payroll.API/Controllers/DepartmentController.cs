using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
        {
            return await _unitOfWork.Department.GetAllDepartments();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return  _unitOfWork.Department.Find(x => x.Id ==id).Result.FirstOrDefault();
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task Post([FromBody] Department department)
        {
           await _unitOfWork.Department.Add(department);
            _unitOfWork.Save();
            
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Department department)
        {
              await  _unitOfWork.Department.UpdateDepartment(department);
                _unitOfWork.Save();   
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
              await  _unitOfWork.Department.DeleteDepartment(id);
            _unitOfWork.Save();  
               
        }
    }
}
