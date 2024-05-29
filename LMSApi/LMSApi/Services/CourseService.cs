using LMSApi.Configuration;
using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class CourseService
	{
		private readonly LMSDbContext _context;

		public CourseService(LMSDbContext context)
		{
			_context = context;
		}

		public List<Course> GetCourses()
		{
			return _context.Courses.ToList();
		}

		public Course GetCourseById(int id)
		{
			return _context.Courses
				.Where(c => c.CourseId == id)
				.Include(c => c.Modules.Where(m => m.ParentId == null))
				.ThenInclude(m => m.SubModules)
				.ThenInclude(s => s.Codelabs)
				.Include(c => c.Modules.Where(m => m.ParentId == null))
				.ThenInclude(m => m.Codelabs)
				.AsNoTracking()
				.FirstOrDefault();
		}

		public Course GetCourseByName(string name)
		{
			return _context.Courses.Where(c => c.CourseName == name).FirstOrDefault();
		}

		public Course CreateCourse(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
			return course;
		}

		public Course UpdateCourseName(int id, string courseName)
		{
			var newCourse = _context.Courses.Find(id);
			newCourse.CourseName = courseName;
			_context.SaveChanges();
			return newCourse;
		}

		public void DeleteCourse(int id)
		{
			var course = _context.Courses.Find(id);
			_context.Courses.Remove(course);
			_context.SaveChanges();
		}
	}
}
