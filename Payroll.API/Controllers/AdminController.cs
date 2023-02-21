using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<Admin>> Get()
        {
            return _unitOfWork.Administrator.GetAll();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<Admin> Get(int id)
        {
            Admin admin = null;
            var result = _unitOfWork.Administrator.Find(a => a.id == id).FirstOrDefault();
            if (result != null)
                admin = result;

            return admin;

        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task Post([FromBody] Admin admin)
        {
           await _unitOfWork.Administrator.Add(admin);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Admin admin)
        {
            _unitOfWork.Administrator.Update(admin);
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = _unitOfWork.Administrator.Find(a => a.id == id).FirstOrDefault();
            if (result != null)
                _unitOfWork.Administrator.Delete(result);
        }
    }
}
