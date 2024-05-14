using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
    [ApiController]
	[Route("/api/SchoolClass")]
	public class SchoolClassController : ControllerBase
	{
		private readonly SchoolClassEditor _schoolClassEditor;
		private readonly IMapper _mapper;

		public SchoolClassController(SchoolClassEditor schoolClassEditor,IMapper mapper)
		{
			_schoolClassEditor = schoolClassEditor;
			_mapper = mapper;
		}

		[HttpGet("SchoolClasses")]
		public IActionResult GetSchoolClasses()
		{
			List<SchoolClassSummaryDto> list = new List<SchoolClassSummaryDto>();
			foreach (var schoolclass in _schoolClassEditor.GetSchoolClasses())
			{
				list.Add(_mapper.Map<SchoolClassSummaryDto>(schoolclass));
			}
			return Ok(list);
		}
		[HttpGet("{id}")]
		public IActionResult GetClassById(int id)
		{
		     return Ok(_mapper.Map<SchoolClassSummaryDto>(_schoolClassEditor.GetSchoolClassById(id)));
			
		}

		[HttpGet("ClassOverview/{id}")]
		public IActionResult GetSchoolClassOverview(int id) 
		{
			return Ok(_mapper.Map<SchoolClassOverviewDto>(_schoolClassEditor.GetSchoolClassOverview(id)));
		}

		[HttpPost("Schoolclass")]
		public IActionResult CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
		{
			SchoolClass newSchoolClass = _schoolClassEditor.CreateSchoolClass(createSchoolClassDto);
			return Created($"{newSchoolClass.SchoolClassId}", _mapper.Map<SchoolClassSummaryDto>(newSchoolClass));
		}
	}
}
