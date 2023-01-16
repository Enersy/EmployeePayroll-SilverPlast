using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _unitOfWork.Category.GetAllCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _unitOfWork.Category.GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task Post([FromBody]Category category)
        {
           await _unitOfWork.Category.Add(category);
            _unitOfWork.Save();

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Category Category)
        {
           await _unitOfWork.Category.UpdateCategory(Category);
            _unitOfWork.Save();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _unitOfWork.Category.DeleteCategory(id);
            _unitOfWork.Save();
        }
    }
}
