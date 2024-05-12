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

		[HttpGet("{id}")]
		public IActionResult GetCourseById(int id)
		{
			return Ok(_courseService.GetCourseById(id));
		}

		[HttpPost]
		public IActionResult CreateCourse(CreateCourseDto createCourseDto)
		{
			var newCourse = _courseEditor.CreateCourse(createCourseDto);
			return Created($"/api/courses/{newCourse.CourseId}", newCourse);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCourseName(int id, CourseNameDto courseNameDto)
		{
			var newCourse = _courseEditor.UpdateCourseName(id, courseNameDto);
			return Created($"/api/courses/{newCourse.CourseId}", newCourse);
		}
	}
}
