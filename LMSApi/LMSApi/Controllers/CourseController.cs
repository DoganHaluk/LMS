using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
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
		private readonly IMapper _mapper;

		public CourseController(CourseEditor courseEditor, CourseService courseService, IMapper mapper)
		{
			_courseEditor = courseEditor;
			_courseService = courseService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetCourses()
		{
			return Ok(_courseService.GetCourses());
		}

		[HttpGet("{id}")]
		public IActionResult GetCourseById(int id)
		{
			return Ok(_mapper.Map<CourseOverviewDto>(_courseService.GetCourseById(id)));
		}

		[HttpPost]
		public IActionResult CreateCourse(CreateCourseDto courseDto)
		{
			var newCourse = _courseEditor.CreateCourse(courseDto);
			return Created($"/api/courses/{newCourse.CourseId}", _mapper.Map<CourseDto>(newCourse));
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCourseName(int id, CreateCourseDto courseDto)
		{
			var newCourse = _courseEditor.UpdateCourseName(id, courseDto);
			return Created($"/api/courses/{newCourse.CourseId}", _mapper.Map<CourseDto>(newCourse));
		}
	}
}
