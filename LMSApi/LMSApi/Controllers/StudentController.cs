using AutoMapper;
using LMSApi.Configuration;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Switchfully.DotNetToolkit.Authentication;

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

		[HttpGet]
		public IActionResult GetAllStudents()
		{
			return Ok(_mapper.Map<List<StudentSummaryDto>>(_studentEditor.GetAllStudents()));
		}


		[HttpGet("{id}")]
		//[authorizescope("coach,student")]
		public IActionResult GetStudentById(int id)
		{
			return Ok(_mapper.Map<StudentSummaryDto>(_studentEditor.GetStudentById(id)));
		}
		
		[HttpPost("")]
		public IActionResult CreateStudent(CreateStudentDto createStudentDto)
		{
			List<InputError> validations = _studentEditor.ValidateRegisterStudent(createStudentDto);
			if (validations.Count > 0)
			{
				return BadRequest(validations);
			}
			else
			{
				Student newStudent = _studentEditor.CreateStudent(_mapper.Map<Student>(createStudentDto));
				return Created($"{newStudent.UserId}", _mapper.Map<StudentSummaryDto>(newStudent));
			}
		}

		[HttpPost("{id}")]
		[AuthorizeScope("Student")]
		public IActionResult EditStudentProfile(int id,EditStudentProfileDto editStudentProfileDto)
		{
			List<InputError> validations = _studentEditor.ValidateStudentProfileEdition(id,editStudentProfileDto);
			if (validations.Count > 0)
			{
				return BadRequest(validations);
			}
			else
			{
				Student update = _studentEditor.EditStudentProfile(id, editStudentProfileDto);
				return Ok(_mapper.Map<StudentSummaryDto>(update));
			}
		}

		[HttpPost("/editpass/{id}")]
		[AuthorizeScope("Student")]
		public IActionResult EditStudentPassword(int id,EditStudentPasswordDto editStudentPasswordDto)
		{
			List<InputError> validations = _studentEditor.ValidateStudentPasswordEdition(id,editStudentPasswordDto);
			if (validations.Count > 0)
			{
				return BadRequest(validations);
			}
			else
			{
				Student update = _studentEditor.EditStudentPassword(id, editStudentPasswordDto);
				return Ok(_mapper.Map<StudentSummaryDto>(update));
			}
		}
	}
}
