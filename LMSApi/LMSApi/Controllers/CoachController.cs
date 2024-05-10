using AutoMapper;
using LMSApi.Configuration;
using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
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
			GetCoachProfileDto getCoachProfile = _mapper.Map<GetCoachProfileDto>(_coachService.GetCoach(id));
			return Ok(getCoachProfile);
		}

	}
}