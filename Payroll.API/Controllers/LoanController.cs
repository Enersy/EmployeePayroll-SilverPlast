using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public LoanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<LoanController>
        [HttpGet]
        public async Task<IEnumerable<Loan>> Get()
        {
            return _unitOfWork.Loan.GetAll();
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public async Task<Loan> Get(int id)
        {  
            Loan loan = null;
            var result = _unitOfWork.Loan.Find(l => l.Id == id).FirstOrDefault();
            if (result != null)
                 loan = result;
            return loan;
        }

        // POST api/<LoanController>
        [HttpPost]
        public async Task Post([FromBody] Loan loan)
        {
            _unitOfWork.Loan.Add(loan);
        }

        // PUT api/<LoanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Loan loan)
        {
            _unitOfWork.Loan.Update(loan);
        }

        // DELETE api/<LoanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var loan = _unitOfWork.Loan.Find(l => l.Id == id).FirstOrDefault();
            if (loan !=null)
            {
                _unitOfWork.Loan.Delete(loan);
            }
            
        }
    }
}
