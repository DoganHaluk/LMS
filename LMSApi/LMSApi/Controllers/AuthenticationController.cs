using LMSApi.Services;
using LMSBase.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly StudentService _studentService;
		private readonly CoachService _coachService;

		public AuthenticationController(StudentService studentService, CoachService coachService)
		{
			_studentService = studentService;
			_coachService = coachService;
		}


		[HttpGet]
		public IActionResult Authenticate(string email, string password) 
		{ 
			Student student = _studentService.GetStudentByEmailAndPassword(email, password);
			Coach coach = _coachService.GetCoachByEmailAndPassword(email,password);
			if(student != null)
			{
				return Ok(_studentService.GenerateJwtToken(student));
			}
			else if(coach != null)
			{
				return Ok(_coachService.GenerateJwtToken(coach));
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
