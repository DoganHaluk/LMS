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

		public CoachController(CoachService coachService)
		{
			_coachService = coachService;
		}

		[HttpPost("")]

		public IActionResult CreateCoach(CreateCoachDto coachDto)
		{
			Coach newCoach = _coachService.CreateCoach(CoachMapper.ToDomain(coachDto));
			return Created($"{newCoach.UserId }",CoachMapper.ToDto(newCoach));
		}
	}
}
