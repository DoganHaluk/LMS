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

		public StudentEditor (StudentService studentService)
		{
			_studentService = studentService;
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

		public Student CreateStudent(Student student)
		{
			return _studentService.CreateStudent(student);
		}

		public Student EditStudentProfile(EditStudentProfileDto editStudent)
		{
			Student updatedStudent = _studentService.GetStudentById(editStudent.UserId);
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

		public Student EditStudentPassword(EditStudentPasswordDto editStudentPasswordDto)
		{
			Student updatedStudent = _studentService.GetStudentById(editStudentPasswordDto.UserId);
			if (updatedStudent.Password != editStudentPasswordDto.Password && !editStudentPasswordDto.Password.IsNullOrEmpty())
			{
				updatedStudent.Password = editStudentPasswordDto.Password;
			}
			return _studentService.EditStudentPassword(updatedStudent);
		}




	}
}
