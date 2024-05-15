using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
    [ApiController]
	[Route("api/student")]
	public class StudentController : ControllerBase
	{
		private readonly StudentEditor _studentEditor;
		private readonly IMapper _mapper;

		public StudentController(StudentEditor studentEditor,IMapper mapper)
		{
			_studentEditor = studentEditor;
			_mapper = mapper;
		}


		[HttpGet("{id}")]
		public IActionResult GetStudentById(int id)
		{
			return Ok(_mapper.Map<StudentSummaryDto>(_studentEditor.GetStudentById(id)));
		}
		
		[HttpPost("")]

		public IActionResult CreateStudent(CreateStudentDto createStudentDto)
		{
			Student newStudent = _studentEditor.CreateStudent(_mapper.Map<Student>(createStudentDto));
			return Created($"{newStudent.UserId}", _mapper.Map<StudentSummaryDto>(newStudent));
		}

		[HttpPost("{id}")]

		public IActionResult EditStudentProfile(EditStudentProfileDto editStudentProfileDto)
		{
			Student update = _studentEditor.EditStudentProfile(editStudentProfileDto);
			return Ok(_mapper.Map<StudentSummaryDto>(update));
		}

		[HttpPost("/editpass/{id}")]

		public IActionResult EditStudentPassword(EditStudentPasswordDto editStudentPasswordDto)
		{
			Student update = _studentEditor.EditStudentPassword(editStudentPasswordDto);
			return Ok(_mapper.Map<StudentSummaryDto>(update));
		}


	}
}
