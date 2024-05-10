using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[ApiController]
	[Route("/api/SchoolClass")]
	public class SchoolClassController : ControllerBase
	{
		private readonly SchoolClassEditor _schoolClassEditor;

		public SchoolClassController(SchoolClassEditor schoolClassEditor)
		{
			_schoolClassEditor = schoolClassEditor;
		}

		[HttpGet("Schoolclasses")]
		public IActionResult GetSchoolClasses()
		{
			return Ok(_schoolClassEditor.GetSchoolClasses());
		}

		[HttpGet("Schoolclasses/{id}")]
		public IActionResult GetSchoolClassOverview(int id) 
		{
			return Ok(_schoolClassEditor.GetSchoolClassOverview(id));
		}

		[HttpPost("Schoolclasses")]

		public IActionResult CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
		{
			CreateSchoolClassDto newSchoolClass = _schoolClassEditor.CreateSchoolClass(createSchoolClassDto);
			return Created($"{newSchoolClass.SchoolClassId}", newSchoolClass);
		}
	}
}
