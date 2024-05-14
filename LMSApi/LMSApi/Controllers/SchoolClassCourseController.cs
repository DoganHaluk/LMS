using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchoolClassCourseController : ControllerBase
	{
		private readonly SchoolClassCourseEditor _schoolClassCourseEditor;
		private readonly IMapper _mapper;

		public SchoolClassCourseController(SchoolClassCourseEditor schoolClassCourseEditor, IMapper mapper)
		{
			_schoolClassCourseEditor = schoolClassCourseEditor;
			_mapper = mapper;
		}

		[HttpPost]
		public IActionResult AddCoursesToSchoolClass(CreateSchoolClassCourseDto createSchoolClassCourseDto)
		{
			return StatusCode(201, _mapper.Map<List<SchoolClassCourseDto>>(_schoolClassCourseEditor.CreateSchoolClassCourse(createSchoolClassCourseDto)));
		}
	}
}
