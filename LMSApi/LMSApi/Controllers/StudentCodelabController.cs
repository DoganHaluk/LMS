using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Switchfully.DotNetToolkit.Authentication;

namespace LMSApi.Controllers
{
	[ApiController]
	[Route("api/studentcodelabs")]
	
	public class StudentCodelabController : ControllerBase
	{
		private readonly StudentCodelabEditor _studentCodelabEditor;
		private readonly IMapper _mapper;

		public StudentCodelabController(StudentCodelabEditor studentCodelabEditor, IMapper mapper)
		{
			_studentCodelabEditor = studentCodelabEditor;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		[AuthorizeScope("Student")]
		public IActionResult GetStudentCodelabs(int id)
		{
			return Ok(_mapper.Map<List<StudentCodelabSummaryDto>>(_studentCodelabEditor.GetStudentCodelabs(id))); 
		}

		[HttpPost]
		[AuthorizeScope("Student")]
		public IActionResult CreateStudentCodelab(CreateStudentCodelabDto createStudentCodelabDto)
		{
			var newStudentCodelab = _studentCodelabEditor.CreateStudentCodelab(_mapper.Map<StudentCodelab>(createStudentCodelabDto));
			return Created($"{newStudentCodelab.StudentCodelabId}", _mapper.Map<StudentCodelabSummaryDto>(newStudentCodelab));
		}

		[HttpPost("{id}")]
		[AuthorizeScope("Student")]
		public IActionResult UpdateStudentCodelab(StudentCodelabSummaryDto studentCodelab)
		{
			return Ok(_studentCodelabEditor.UpdateStudentCodelab(studentCodelab));
		}


		[HttpGet("progression")]
		[AuthorizeScope("Coach")]
		public IActionResult GetProgressions(int schoolClassId=0,int moduleId=0)
		{
			return Ok(_mapper.Map<List<ProgressionDto>>(_studentCodelabEditor.GetProgressions(schoolClassId, moduleId)));
		}

	}
}
