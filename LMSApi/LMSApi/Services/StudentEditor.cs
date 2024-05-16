using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;

namespace LMSApi.Services
{
	public class StudentEditor
	{
		private readonly StudentService _studentService;
		//private readonly HttpContext _httpContext;
		private readonly SchoolClassService _schoolClassService;

		public StudentEditor (StudentService studentService, /*IHttpContextAccessor httpContextAccessor,*/SchoolClassService schoolClassService)
		{
			_studentService = studentService;
			//_httpContext = httpContextAccessor.HttpContext;
			_schoolClassService = schoolClassService;
		}


		public List<Student> GetAllStudents()
		{
			return _studentService.GetAllStudents();
		}

		public Student GetStudentById(int id)
		{
			return _studentService.GetStudentById(id);
		}

		public Student GetStudentByEmail(string email)
		{
			return _studentService.GetStudentByEmail(email);
		}

		public List<InputError> ValidateRegisterStudent(CreateStudentDto createStudentDto)
		{
			List<InputError> errors = new List<InputError>();
			InputError nameError = InputError.CheckName(createStudentDto.UserName);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			List<InputError> emailError = InputError.CheckEmail(createStudentDto.Email);
			if (emailError != null)
			{
				foreach (InputError error in emailError)
				{
					errors.Add(error);
				}
			}
			InputError passwordError = InputError.CheckRepeatPassword(createStudentDto.Password, createStudentDto.RepeatPassword);
			if (passwordError != null)
			{
				errors.Add(passwordError);
			}
			return errors;
		}

		public Student CreateStudent(Student student)
		{
			return _studentService.CreateStudent(student);
		}

		public List<InputError> ValidateStudentProfileEdition(int id,EditStudentProfileDto editStudentProfileDto)
		{
			List<InputError> errors = new List<InputError> ();
			//var claim = _httpContext.User.Claims.First(c => c.Type == "userId");
			//int tokenId = Convert.ToInt32(claim.Value);
			//InputError ownerError = InputError.CheckOwner(id, tokenId);
			//if (ownerError != null)
			//{
			//	errors.Add(ownerError);
			//}
			if (!editStudentProfileDto.UserName.IsNullOrEmpty())
			{
				InputError nameError = InputError.CheckName(editStudentProfileDto.UserName);
				if (nameError != null)
				{
					errors.Add(nameError);
				}
			}
			if (!editStudentProfileDto.Email.IsNullOrEmpty())
			{
				List<InputError> emailError = InputError.CheckEmail(editStudentProfileDto.Email);
				if (emailError != null)
				{
					foreach (InputError error in emailError)
					{
						errors.Add(error);
					}
				}
			}
			if (editStudentProfileDto.SchoolClassId > 0)
			{
				var schoolClass = _schoolClassService.GetSchoolClassById(editStudentProfileDto.SchoolClassId);
				if (schoolClass == null)
				{
					errors.Add(InputError.CheckSchoolClass());
				}
			}
			return errors;
		}

		public Student EditStudentProfile(int id, EditStudentProfileDto editStudent)
		{
			Student updatedStudent = _studentService.GetStudentById(id);
			if (updatedStudent.UserName !=  editStudent.UserName && !editStudent.UserName.IsNullOrEmpty()) 
			{
				updatedStudent.UserName = editStudent.UserName;
			}
			if (updatedStudent.Email != editStudent.Email && !editStudent.Email.IsNullOrEmpty())
			{
				updatedStudent.Email = editStudent.Email;
			}
			if (updatedStudent.SchoolClassId != editStudent.SchoolClassId && editStudent.SchoolClassId > 0)
			{
				updatedStudent.SchoolClassId = editStudent.SchoolClassId;
			}
			return _studentService.EditStudentProfile(updatedStudent);
		}

		public List<InputError> ValidateStudentPasswordEdition(int id,EditStudentPasswordDto editStudentPasswordDto)
		{
			List<InputError> errors = new List<InputError>();
			//var claim = _httpContext.User.Claims.First(c => c.Type == "userId");
			//int tokenId = Convert.ToInt32(claim.Value);
			//InputError ownerError = InputError.CheckOwner(id, tokenId);
			//if (ownerError != null)
			//{
			//	errors.Add(ownerError);
			//}
			InputError passwordError = InputError.CheckRepeatPassword(editStudentPasswordDto.Password, editStudentPasswordDto.RepeatPassword);
			if (passwordError != null)
			{
				errors.Add(passwordError);
			}
			return errors;
		}

		public Student EditStudentPassword(int id,EditStudentPasswordDto editStudentPasswordDto)
		{
			Student updatedStudent = _studentService.GetStudentById(id);
			if (updatedStudent.Password != editStudentPasswordDto.Password && !editStudentPasswordDto.Password.IsNullOrEmpty())
			{
				updatedStudent.Password = editStudentPasswordDto.Password;
			}
			return _studentService.EditStudentPassword(updatedStudent);
		}
	}
}
