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
            return await _unitOfWork.Attendance.GetAllAttendance();
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public async Task<Attendance> Get(int id)
        {
            return (Attendance)await _unitOfWork.Attendance.Find(x =>x.Id == id);
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task Post([FromBody] Attendance attendance)
        {
            await _unitOfWork.Attendance.Add(attendance);
            _unitOfWork.Save();
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Attendance attendance)
        {
            await _unitOfWork.Attendance.UpdateAttendance(attendance);
            _unitOfWork.Save();
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _unitOfWork.Attendance.DeleteAttendance(id);
            _unitOfWork.Save();
        }
    }
}
