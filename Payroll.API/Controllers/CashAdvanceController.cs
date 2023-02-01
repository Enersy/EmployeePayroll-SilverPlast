using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashAdvanceController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public CashAdvanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<CashAdvanceController>
        [HttpGet]
        public async Task<IEnumerable<CashAdvance>> Get()
        {
            return _unitOfWork.CashAdvance.GetAll();
        }

        // GET api/<CashAdvanceController>/5
        [HttpGet("{id}")]
        public async Task<CashAdvance> Get(int id)
        {
            return  _unitOfWork.CashAdvance.Find(x =>x.Id == id).FirstOrDefault();
        }

        // POST api/<CashAdvanceController>
        [HttpPost]
        public async Task Post([FromBody] CashAdvance cashAdvance)
        {
           await _unitOfWork.CashAdvance.Add(cashAdvance);
        }

        // PUT api/<CashAdvanceController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CashAdvance cashAdvance)
        {
           await _unitOfWork.CashAdvance.Update(cashAdvance);
        }

        // DELETE api/<CashAdvanceController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var ws = _unitOfWork.CashAdvance.Find(x => x.Id == id).FirstOrDefault();
            if (ws != null)
            {
                await _unitOfWork.CashAdvance.Delete(ws);
            }
        }
    }
}
