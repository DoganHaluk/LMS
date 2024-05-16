using AutoMapper;
using LMSApi.Configuration;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[ApiController]
	[Route("api/codelabs")]
	public class CodelabController : ControllerBase
	{
		private readonly CodelabEditor _codelabEditor;
		private readonly IMapper _mapper;

		public CodelabController(CodelabEditor codelabEditor, IMapper mapper)
		{
			_codelabEditor = codelabEditor;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAllCodelabs()
		{
			List<CodelabSummaryDto> codelabsDto = new List<CodelabSummaryDto>();
			var codelabs = _codelabEditor.GetAllCodelabs();
			foreach (var codelab in codelabsDto)
			{
				codelabsDto.Add(_mapper.Map<CodelabSummaryDto>(codelab));
			}
			return Ok(codelabsDto);
		}

		[HttpGet("{id}")]
		public IActionResult GetCodelabById(int id) 
		{
			return Ok(_mapper.Map<CodelabSummaryDto>(_codelabEditor.GetCodelabById(id)));
		}

		[HttpPost]
		public IActionResult CreateCodelab(CreateCodelabDto createCodelabDto)
		{
			List<InputError> errors = _codelabEditor.ValidateCodelabCreation(createCodelabDto);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				var newCodelab = _codelabEditor.CreateCodelab(_mapper.Map<Codelab>(createCodelabDto));
				return Created($"{newCodelab.CodelabId}", _mapper.Map<CodelabSummaryDto>(newCodelab));
			}
		}

		[HttpPost("{id}")]
		public IActionResult EditCodelab(int id,EditCodelabDto editCodelabDto)
		{
			List<InputError> errors = _codelabEditor.ValidateCodelabEdition(id, editCodelabDto);
			if (errors.Count > 0)
			{
				return BadRequest(errors);
			}
			else
			{
				return Ok(_mapper.Map<CodelabSummaryDto>(_codelabEditor.UpdateCodelab(id, editCodelabDto)));
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCodelab(int id)
		{
			_codelabEditor.DeleteCodelab(id);
			return NoContent();
		}
	}
}
