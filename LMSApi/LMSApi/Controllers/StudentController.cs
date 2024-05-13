using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[ApiController]
	[Route("api/student")]
	public class StudentController : ControllerBase
	{
		private readonly StudentService _studentService;
		private readonly IMapper _mapper;

		public StudentController(StudentService studentService,IMapper mapper)
		{
			_studentService = studentService;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public IActionResult GetStudentById(int id)
		{
			return Ok(_mapper.Map<GetStudentDto>(_studentService.GetStudentById(id)));
		}
		
		[HttpPost("")]

		public IActionResult CreateStudent(CreateStudentDto createStudentDto)
		{
			Student newStudent = _studentService.CreateStudent(_mapper.Map<Student>(createStudentDto));
			return Created($"{newStudent.UserId}", _mapper.Map<GetStudentDto>(newStudent));
		}

		[HttpPost("{id}")]

		public IActionResult UpdateStudentWithSchoolClass(StudentForClassUpdate studentForClassUpdate)
		{
			Student update = _studentService.UpdateStudentWithSchoolClass(_mapper.Map<Student>(studentForClassUpdate));
			return Ok(_mapper.Map<GetStudentDto>(update));
		}


	}
}
