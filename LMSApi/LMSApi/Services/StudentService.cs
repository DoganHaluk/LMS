using LMSApi.Configuration;
using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

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

		public Student GetStudentById(int id)
		{
			return _context.Students.Where(s=>s.UserId==id).Include(s=>s.SchoolClass).FirstOrDefault();
		}

		public Student GetStudentByEmail(string email)
		{
			return _context.Students.Where(s => s.Email == email).FirstOrDefault();
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
