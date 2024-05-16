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

		public SchoolClassCourse GetSchoolClassCourseWithClassAndCourseId(int courseId,int classId)
		{
			return _context.SchoolClassCourses.Where(c => c.CourseId == courseId).Where(s => s.SchoolClassId == classId).FirstOrDefault();
		}

		public SchoolClassCourse CreateSchoolClassCourse(SchoolClassCourse schoolClassCourse)
		{
			_context.SchoolClassCourses.Add(schoolClassCourse);
			_context.SaveChanges();
			return schoolClassCourse;
		}

		public void DeleteSchoolClassCourse(int id) 
		{
			var delete = _context.SchoolClassCourses.Find(id);
			_context.SchoolClassCourses.Remove(delete);
			_context.SaveChanges();
		}
	}
}
