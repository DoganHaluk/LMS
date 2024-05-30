using LMSApi.Services;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
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


		[HttpPost]
		public IActionResult Authenticate(LoginDto login) 
		{ 
			AuthenticatedDto authenticatedDto = new AuthenticatedDto();
			Student student = _studentService.GetStudentByEmailAndPassword(login);
			Coach coach = _coachService.GetCoachByEmailAndPassword(login);
			if(student != null)
			{
				authenticatedDto.UserId = student.UserId;
				authenticatedDto.Role = "Student";
				authenticatedDto.UserName = student.UserName;
				authenticatedDto.Token = _studentService.GenerateJwtToken(student);
				return Ok(authenticatedDto);
			}
			else if(coach != null)
			{
				authenticatedDto.UserId = coach.UserId;
				authenticatedDto.Role = "Coach";
				authenticatedDto.UserName = coach.UserName;
				authenticatedDto.Token = _coachService.GenerateJwtToken(coach);
				return Ok(authenticatedDto);
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
