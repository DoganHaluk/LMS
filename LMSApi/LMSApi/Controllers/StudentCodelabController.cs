using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

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
		public IActionResult GetStudentCodelab(int id)
		{
			return Ok(_mapper.Map<StudentCodelabSummaryDto>(_studentCodelabEditor.GetStudentCodelab(id))); 
		}

		[HttpPost]
		public IActionResult CreateStudentCodelab(CreateStudentCodelabDto createStudentCodelabDto)
		{
			var newStudentCodelab = _studentCodelabEditor.CreateStudentCodelab(_mapper.Map<StudentCodelab>(createStudentCodelabDto));
			return Created($"{newStudentCodelab.StudentCodelabId}", _mapper.Map<StudentCodelabSummaryDto>(newStudentCodelab));
		}

		[HttpPost("{id}")]

		public IActionResult UpdateStatus(int id, UpdateStatusCodelabDto updateStatusCodelabDto)
		{
			return Ok(_studentCodelabEditor.UpdateStatus(id,_mapper.Map<StudentCodelab>(updateStatusCodelabDto)));
		}

		[HttpPost("comment/{id}")]
		public IActionResult AddComment(int id,AddCommentDto addCommentDto)
		{
			return Ok(_studentCodelabEditor.UpdateComment(id,_mapper.Map<StudentCodelab>(addCommentDto)));
		}



	}
}
