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
		

		[HttpGet("{id}")]
		[AuthorizeScope("Coach,Student")]
		public IActionResult GetCoach(int id)
		{
			return Ok(_mapper.Map<CoachSummaryDto>(_coachService.GetCoach(id)));
		}

		[HttpPost("")]
		[AuthorizeScope("Coach")]
		public IActionResult CreateCoach(CreateCoachDto coachDto)
		{
			Coach newCoach = _coachService.CreateCoach(_mapper.Map<Coach>(coachDto));
			return Created($"{newCoach.UserId}", _mapper.Map<CoachSummaryDto>(newCoach));
		}
	}
}