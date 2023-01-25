using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceRateSalaryDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public PieceRateSalaryDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<PieceRateSalaryDetailsController>
        [HttpGet]
        public async Task<IEnumerable<EmpPieceRateSalaryDetails>> Get()
        {
            return await _unitOfWork.PieceRate.GetAll();
        }

        // GET api/<PieceRateSalaryDetailsController>/5
        [HttpGet("{id}")]
        public EmpPieceRateSalaryDetails Get(int id)
        {
            var ws = _unitOfWork.PieceRate.Find(x => x.TransactionId == id).Result.FirstOrDefault();
            return ws;
        }

        // POST api/<PieceRateSalaryDetailsController>
        [HttpPost]
        public void Post([FromBody] EmpPieceRateSalaryDetails value)
        {
            _unitOfWork.PieceRate.Add(value);
            _unitOfWork.Save();
        }

        // PUT api/<PieceRateSalaryDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmpPieceRateSalaryDetails value)
        {
            _unitOfWork.PieceRate.Update(value);
        }

        // DELETE api/<PieceRateSalaryDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ws = _unitOfWork.PieceRate.Find(x => x.TransactionId == id).Result.FirstOrDefault();
            if (ws != null)
            {
                _unitOfWork.PieceRate.Delete(ws);
            }
        }
    }
}
