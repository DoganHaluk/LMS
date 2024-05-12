using LMSApi.Configuration;
using LMSBase.Models.Domain;

namespace LMSApi.Services
{
	public class CourseService
	{
		private readonly LMSDbContext _context;

		public CourseService(LMSDbContext context)
		{
			_context = context;
		}

		public Course GetCourseById(int id)
		{
			return _context.Courses.Find(id);
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
	}
}
