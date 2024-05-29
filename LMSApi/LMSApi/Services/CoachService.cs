using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Switchfully.DotNetToolkit.Authentication.JwtUtilities;

namespace LMSApi.Services
{
	public class CoachService
	{
		private readonly LMSDbContext _context;

		public CoachService(LMSDbContext context)
		{
			_context = context;
		}

		public List<Coach> GetCoaches()
		{
			return _context.Coaches.ToList();
		}

		public Coach GetCoach(int id)
		{
			return _context.Coaches.Where(c=>c.UserId == id).Include(c=>c.CoachSchoolClasses).ThenInclude(s=>s.SchoolClass).FirstOrDefault();
		}

		public Coach GetCoachByEmailAndPassword(LoginDto login)
		{
			Coach coach = _context.Coaches.Where(c => c.Email == login.Email).Where(c => c.Password == login.Password).FirstOrDefault();
			if (coach != null) 
			{
				coach.Claims.Add(new Claim("scope", "Coach"));
				return coach;
			}
			else
			{
				return null;
			}			
		}

		public virtual string GenerateJwtToken(Coach coach)
		{
			// set coach audience
			var userAudiences = new List<string> { "SwitchfullyAudience" };

			// set coach claims
			var userClaims = new List<Claim> { new Claim("name", coach.Email), new Claim("userId", $"{coach.UserId}") };

			// add permissions
			foreach (var claim in coach.Claims)
			{
				userClaims.Add(new Claim("scope", claim.Value));
			}

			// create JWT for coach to access ContentApi
			JwtSecurityToken userToken = GenerateJwtSecurityTokenWithAsymmetricSigning(new JwtTokenOptions() { Issuer = "SwitchFullyAuthenticator", Audiences = userAudiences, UserName = coach.Email, Claims = userClaims, SigningKey = PrivateKey, MinutesToExpiration = 120, });

			return userToken.Serialize();
		}



		public Coach CreateCoach(Coach coach)
		{
			_context.Coaches.Add(coach);
			_context.SaveChanges();
			return coach;
		}

		public void UpdateCoach(int id, EditCoachDto coach)
		{
			var update = _context.Coaches.Find(id);
			update.UserName = coach.UserName;
			update.Email = coach.Email;
			_context.SaveChanges();
		}


	}
}
