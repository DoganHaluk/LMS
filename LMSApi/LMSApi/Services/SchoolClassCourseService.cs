using LMSApi.Configuration;
using LMSBase.Models.Domain;

namespace LMSApi.Services
{
	public class SchoolClassCourseService
	{
		private readonly LMSDbContext _context;

		public SchoolClassCourseService(LMSDbContext context)
		{
			_context = context;
		}

		public SchoolClassCourse CreateSchoolClassCourse(SchoolClassCourse schoolClassCourse)
		{
			_context.SchoolClassCourses.Add(schoolClassCourse);
			_context.SaveChanges();
			return schoolClassCourse;
		}
	}
}
