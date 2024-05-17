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
	[Route("api/[controller]")]
	[ApiController]
	[AuthorizeScope("Coach")]
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
			List<InputError> validations = _schoolClassCourseEditor.ValidateAddCourses(createSchoolClassCourseDto);
			if (validations.Count > 0)
			{
				return BadRequest(validations);
			}
			else
			{
				return StatusCode(201, _mapper.Map<List<SchoolClassCourseDto>>(_schoolClassCourseEditor.CreateSchoolClassCourse(createSchoolClassCourseDto)));
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSchoolClassCourse(int id)
		{
			_schoolClassCourseEditor.DeleteSchoolClassCourse(id);
			return NoContent();
		}
	}
}
