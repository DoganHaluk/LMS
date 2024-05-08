using LMSApi.Services;
using LMSBase.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[ApiController]
	[Route("/api/SchoolClass")]
	public class SchoolClassController : Controller
	{
		private readonly SchoolClassService _schoolClassService;

		public SchoolClassController(SchoolClassService schoolClassService)
		{
			_schoolClassService = schoolClassService;
		}

		[HttpGet]
		public IActionResult GetSchoolClasses()
		{
			return Ok(_schoolClassService.GetSchoolClasses());
		}


		[HttpGet]
		public IActionResult GetSchoolClassOverview(int id) 
		{
			return Ok(_schoolClassService.GetSchoolClassOverview(id));
		}

		[HttpPost]

		public IActionResult CreateSchoolClass(SchoolClass schoolClass)
		{
			SchoolClass newSchoolClass = _schoolClassService.CreateSchoolClass(schoolClass);
			return Created($"{newSchoolClass.SchoolClassId}", newSchoolClass);
		}

	}
}
