using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Switchfully.DotNetToolkit.Authentication.JwtUtilities;

namespace LMSApi.Services
{
	public class StudentService
	{
		private readonly LMSDbContext _context;

		public StudentService(LMSDbContext context)
		{
			_context = context;
		}

		public List<Student> GetAllStudents()
		{
			return _context.Students.ToList();
		}

		public List<Student> GetStudentsFromClass(int schoolClassId)
		{
			return _context.Students.Where(s=>s.SchoolClassId == schoolClassId).ToList();
		}

		public Student GetStudentById(int id)
		{
			return _context.Students.Where(s=>s.UserId==id).Include(s=>s.SchoolClass).FirstOrDefault();
		}

		public Student GetStudentByEmail(string email)
		{
			return _context.Students.Where(s => s.Email == email).FirstOrDefault();
		}

		public Student GetStudentByEmailAndPassword(LoginDto login)
		{
			Student student = _context.Students.Where(s => s.Email == login.Email).Where(s => s.Password == login.Password).FirstOrDefault();
			if (student != null)
			{
				student.Claims.Add(new Claim("scope", "Student"));
				return student;
			}
			else
			{
				return null;
			}
		}

		public virtual string GenerateJwtToken(Student student)
		{
			// set student audience
			var userAudiences = new List<string> { "SwitchfullyAudience" };

			// set student claims
			var userClaims = new List<Claim> { new Claim("name", student.Email), new Claim("userId", $"{student.UserId}") };

			// add permissions
			foreach (var claim in student.Claims)
			{
				userClaims.Add(new Claim("scope", claim.Value));
			}

			// create JWT for student to access ContentApi
			JwtSecurityToken userToken = GenerateJwtSecurityTokenWithAsymmetricSigning(new JwtTokenOptions() { Issuer = "SwitchFullyAuthenticator", Audiences = userAudiences, UserName = student.Email, Claims = userClaims, SigningKey = PrivateKey, MinutesToExpiration = 120, });

			return userToken.Serialize();
		}


		public Student CreateStudent(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return student;
		}

		public Student EditStudentProfile(Student student)
		{
			var updatedStudent = _context.Students.Find(student.UserId);
			updatedStudent = student;
			_context.SaveChanges();
			return updatedStudent;
		}

		public Student EditStudentPassword(Student student)
		{
			var updatedStudent = _context.Students.Find(student.UserId);
			updatedStudent = student;
			_context.SaveChanges();
			return updatedStudent;
		}
	}
}
