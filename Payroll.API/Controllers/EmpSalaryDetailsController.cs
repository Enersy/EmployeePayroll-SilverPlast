using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpSalaryDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public EmpSalaryDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<EmpSalaryDetailsController>
        [HttpGet]
        public async Task<IEnumerable<EmpSalaryDetails>> Get()
        {
            return _unitOfWork.SalaryDetails.GetAll() ;
        }

        // GET api/<EmpSalaryDetailsController>/5
        [HttpGet("{id}")]
        public async Task< EmpSalaryDetails> Get(int id)
        {
            var ws = _unitOfWork.SalaryDetails.Find(x => x.TransactionId == id).FirstOrDefault();
            return ws;
        }

        // POST api/<EmpSalaryDetailsController>
        [HttpPost]
        public void Post([FromBody] EmpSalaryDetails value)
        {
            _unitOfWork.SalaryDetails.Add(value);
            _unitOfWork.Save();
        }

        // PUT api/<EmpSalaryDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]EmpSalaryDetails value)
        {
            _unitOfWork.SalaryDetails.Update(value);
        }

        // DELETE api/<EmpSalaryDetailsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var ws = _unitOfWork.SalaryDetails.Find(x => x.TransactionId == id).FirstOrDefault();
            if (ws != null)
            {
               await _unitOfWork.SalaryDetails.Delete(ws);
            }
        }
    }
}
