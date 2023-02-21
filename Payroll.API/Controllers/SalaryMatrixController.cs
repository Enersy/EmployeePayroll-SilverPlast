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
            return  _unitOfWork.SalaryMatrix.GetAll();
        }

        // GET api/<SalaryMatrixController>/5
        [HttpGet("{id}")]
        public async Task<SalaryMatrix> Get(int id)
        {
            return (SalaryMatrix) _unitOfWork.SalaryMatrix.Find(x => x.Id == id);
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
            _unitOfWork.SalaryMatrix.Update(salaryMatrix);
            _unitOfWork.Save();
        }

        // DELETE api/<SalaryMatrixController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           var sm = _unitOfWork.SalaryMatrix.Find(x => x.Id == id).FirstOrDefault();
            if (sm != null)
                 await _unitOfWork.SalaryMatrix.Delete(sm);

            _unitOfWork.Save();
        }
    }
}
