using LMSApi.Configuration;
using LMSBase.Models.Domain;

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
			return _context.Students.Find(id);
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

		public Student UpdateStudentWithSchoolClass(int id, int schoolClassId)
		{
			var student = _context.Students.Find(id);
			student.SchoolClassId = schoolClassId;
			_context.SaveChanges();
			return student;
		}
		


		
	}
}
