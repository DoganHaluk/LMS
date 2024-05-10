using System.Reflection;

namespace LMSBase.Models.Domain
{
	public class Course
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public List<LearningModule> Modules { get; set; }
		public List<SchoolClassCourse> SchoolClassCourses { get; set; }
	}
}
