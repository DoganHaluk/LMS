using LMSApi.Services;
using LMSBase.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[Route("api/courses")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly CourseEditor _courseEditor;
		private readonly CourseService _courseService;

		public CourseController(CourseEditor courseEditor, CourseService courseService)
		{
			_courseEditor = courseEditor;
			_courseService = courseService;
		}

		[HttpGet]
		public IActionResult GetCourses()
		{
			return Ok(_courseService.GetCourses());
		}

		[HttpGet("{id}")]
		public IActionResult GetCourseById(int id)
		{
			return Ok(_courseService.GetCourseById(id));
		}

		[HttpPost]
		public IActionResult CreateCourse(CourseDto courseDto)
		{
			var newCourse = _courseEditor.CreateCourse(courseDto);
			return Created($"/api/courses/{newCourse.CourseId}", newCourse);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCourseName(int id, CourseDto courseDto)
		{
			var newCourse = _courseEditor.UpdateCourseName(id, courseDto);
			return Created($"/api/courses/{newCourse.CourseId}", newCourse);
		}
	}
}
