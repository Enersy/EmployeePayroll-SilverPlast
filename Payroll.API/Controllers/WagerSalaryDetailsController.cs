using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagerSalaryDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public WagerSalaryDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<WagerSalaryDetailsController>
        [HttpGet]
        public async Task<IEnumerable<EmpWagerSalaryDetails>> Get()
        {
            return await _unitOfWork.EmpWagerSalaryDetails.GetAll();
        }

        // GET api/<WagerSalaryDetailsController>/5
        [HttpGet("{id}")]
        public async Task<EmpWagerSalaryDetails> Get(int id)
        {
            var ws = _unitOfWork.EmpWagerSalaryDetails.Find(x => x.TransactionId == id).Result.FirstOrDefault();
            return  ws;
        }

        // POST api/<WagerSalaryDetailsController>
        [HttpPost]
        public void Post([FromBody] EmpWagerSalaryDetails value)
        {
            _unitOfWork.EmpWagerSalaryDetails.Add(value);
            _unitOfWork.Save();
        }

        // PUT api/<WagerSalaryDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmpWagerSalaryDetails value)
        {
            _unitOfWork.EmpWagerSalaryDetails.Update(value);
        }

        // DELETE api/<WagerSalaryDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ws = _unitOfWork.EmpWagerSalaryDetails.Find(x => x.TransactionId == id).Result.FirstOrDefault();
            if (ws != null)
            {
                _unitOfWork.EmpWagerSalaryDetails.Delete(ws);
            }
           
        }
    }
}
