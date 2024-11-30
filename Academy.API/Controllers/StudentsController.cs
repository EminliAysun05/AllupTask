using Academy.Application.Dtos;
using Academy.Application.Services.StudentService;
using Academy.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentManager;

        public StudentsController(IStudentService studentService)
        {
            _studentManager = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage([FromQuery]PageRequest pageRequest)
        {
            var studentList = await _studentManager.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);

            return Ok(studentList);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentManager.GetAsync(id.Value);

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StudentCreateDto createDto)
        {
            var createdStudent = await _studentManager.AddAsync(createDto);

            return Ok(createdStudent);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody]StudentUpdateDto updateDto)
        {
            if (id == null) return NotFound();

            var updatedStudent = await _studentManager.UpdateAsync(id.Value, updateDto);

            return Ok(updatedStudent);
        }
    }
}
