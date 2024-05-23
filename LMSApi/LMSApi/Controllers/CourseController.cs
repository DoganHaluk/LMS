using AutoMapper;
using LMSApi.Configuration;
using LMSApi.Services;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Switchfully.DotNetToolkit.Authentication;

namespace LMSApi.Controllers
{
    [Route("api/courses")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly CourseEditor _courseEditor;
		private readonly CourseService _courseService;
		private readonly IMapper _mapper;

		public CourseController(CourseEditor courseEditor, CourseService courseService, IMapper mapper)
		{
			_courseEditor = courseEditor;
			_courseService = courseService;
			_mapper = mapper;
		}

		[HttpGet]
		[AuthorizeScope("Coach,Student")]
		public IActionResult GetCourses()		
		{
			return Ok(_courseService.GetCourses());
		}

		[HttpGet("{id}")]
		//[AuthorizeScope("Coach,Student")]
		public IActionResult GetCourseById(int id)
		{
			List<InputError> errors = _courseEditor.ValidateUserCourseOverview(id);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				return Ok(_mapper.Map<CourseOverviewDto>(_courseEditor.GetCourseById(id)));
			}
		}

		[HttpPost]
		[AuthorizeScope("Coach")]
		public IActionResult CreateCourse(CreateCourseDto courseDto)
		{
			List<InputError> errors = _courseEditor.ValidateCourseCreation(courseDto);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				var newCourse = _courseEditor.CreateCourse(courseDto);
				return Created($"/api/courses/{newCourse.CourseId}", _mapper.Map<CourseDto>(newCourse));
			}
		}

		[HttpPut("{id}")]
		[AuthorizeScope("Coach")]
		public IActionResult UpdateCourseName(int id, CreateCourseDto courseDto)
		{
			List<InputError> errors = _courseEditor.ValidateCourseEdition(id,courseDto);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				var newCourse = _courseEditor.UpdateCourseName(id, courseDto);
				return Created($"/api/courses/{newCourse.CourseId}", _mapper.Map<CourseDto>(newCourse));
			}
		}

		[HttpDelete("{id}")]
		[AuthorizeScope("Coach")]
		public IActionResult DeleteCourse(int id)
		{
			_courseService.DeleteCourse(id);
			return NoContent();
		}
	}
}
