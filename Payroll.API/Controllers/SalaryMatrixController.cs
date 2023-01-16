using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryMatrixController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SalaryMatrixController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<SalaryMatrixController>
        [HttpGet]
        public async Task<IEnumerable<SalaryMatrix>> Get()
        {
            return await _unitOfWork.SalaryMatrix.GetAllSalaryMatrix();
        }

        // GET api/<SalaryMatrixController>/5
        [HttpGet("{id}")]
        public async Task<SalaryMatrix> Get(int id)
        {
            return await _unitOfWork.SalaryMatrix.GetById(id);
        }

        // POST api/<SalaryMatrixController>
        [HttpPost]
        public async Task Post([FromBody] SalaryMatrix salaryMatrix)
        {
           await _unitOfWork.SalaryMatrix.Add(salaryMatrix);
            _unitOfWork.Save();
        }

        // PUT api/<SalaryMatrixController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SalaryMatrix salaryMatrix)
        {
           await _unitOfWork.SalaryMatrix.UpdateSalaryMatrix(salaryMatrix);
            _unitOfWork.Save();
        }

        // DELETE api/<SalaryMatrixController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _unitOfWork.SalaryMatrix.DeleteSalaryMatrix(id);
            _unitOfWork.Save();
        }
    }
}
