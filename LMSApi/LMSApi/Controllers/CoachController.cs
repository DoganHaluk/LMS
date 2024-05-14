using AutoMapper;
using LMSApi.Configuration;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
    [ApiController]
	[Route("/api/coach")]
	public class CoachController : ControllerBase
	{
		private readonly CoachService _coachService;

		private readonly IMapper _mapper;

		public CoachController(CoachService coachService, IMapper mapper)
		{
			_coachService = coachService;
			_mapper = mapper;
		}

		[HttpPost("")]

		public IActionResult CreateCoach(CreateCoachDto coachDto)
		{
			Coach newCoach = _coachService.CreateCoach(CoachMapper.ToDomain(coachDto));
			return Created($"{newCoach.UserId}", newCoach);
		}

		[HttpGet("/{id}")]
		public IActionResult GetCoach(int id)
		{
			CoachSummaryDto getCoachProfile = _mapper.Map<CoachSummaryDto>(_coachService.GetCoach(id));
			return Ok(getCoachProfile);
		}

	}
}