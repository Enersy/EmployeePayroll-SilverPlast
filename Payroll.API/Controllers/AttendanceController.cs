using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<AttendanceController>
        [HttpGet]
        public async Task<IEnumerable<Attendance>> Get()
        {
            return  _unitOfWork.Attendance.GetAll();
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public async Task<Attendance> Get(int id)
        {
          var data =  _unitOfWork.Attendance.Find(x =>x.Id == id).FirstOrDefault();
            return data;
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task Post([FromBody] Attendance attendance)
        {
            await _unitOfWork.Attendance.AddAttendance(attendance);
            _unitOfWork.Save();
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Attendance attendance)
        {
            await _unitOfWork.Attendance.Update(attendance);
            _unitOfWork.Save();
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        { 
            var entity = _unitOfWork.Attendance.Find(x => x.Id == id).FirstOrDefault();
            if (entity != null)
                await _unitOfWork.Attendance.Delete(entity);

            _unitOfWork.Save();
        }
    }
}
