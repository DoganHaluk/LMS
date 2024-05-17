using AutoMapper;
using LMSApi.Configuration;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Switchfully.DotNetToolkit.Authentication;

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
		[AuthorizeScope("Coach,Student")]
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
		[AuthorizeScope("Coach,Student")]
		public IActionResult GetClassById(int id)
		{
		     return Ok(_mapper.Map<SchoolClassSummaryDto>(_schoolClassEditor.GetSchoolClassById(id)));
			
		}

		[HttpGet("ClassOverview/{id}")]
		[AuthorizeScope("Coach,Student")]
		public IActionResult GetSchoolClassOverview(int id) 
		{
			List<InputError> errors = _schoolClassEditor.ValidateUserClassOverview(id);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				return Ok(_mapper.Map<SchoolClassOverviewDto>(_schoolClassEditor.GetSchoolClassOverview(id)));
			}
		}

		[HttpPost("Schoolclass")]
		[AuthorizeScope("Coach")]
		public IActionResult CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
		{
			List<InputError> errors = _schoolClassEditor.ValidateSchoolClassCreation(createSchoolClassDto);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				SchoolClass newSchoolClass = _schoolClassEditor.CreateSchoolClass(createSchoolClassDto);
				return Created($"{newSchoolClass.SchoolClassId}", _mapper.Map<SchoolClassSummaryDto>(newSchoolClass));
			}
			
		}

		[HttpPost("{id}")]
		[AuthorizeScope("Coach")]
		public IActionResult EditSchoolClassName(int id,EditSchoolClassDto editSchoolClassDto)
		{
			List<InputError> errors = _schoolClassEditor.ValidateSchoolClassEdition(id, editSchoolClassDto);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				var updated = _schoolClassEditor.EditSchoolClassName(id, _mapper.Map<SchoolClass>(editSchoolClassDto));
				return Ok(updated);
			}
		}
	}
}
