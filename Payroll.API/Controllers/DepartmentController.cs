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
            return _unitOfWork.Department.GetAllDepartments();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _unitOfWork.Department.GetById(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _unitOfWork.Department.Add(department);
            _unitOfWork.Save();
            
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Department department)
        {
           var dept = _unitOfWork.Department.Find(x => x.Id == department.Id);
            if (dept != null) 
            {
                _unitOfWork.Department.Update(department);
            }
           
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dept = _unitOfWork.Department.GetById(id );
            if (dept != null)
            {
                _unitOfWork.Department.Delete(id);
            }
        }
    }
}
