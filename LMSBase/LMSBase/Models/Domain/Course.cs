using System.Reflection;

namespace LMSBase.Models.Domain
{
	public class Course
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public List<LearningModule> Modules { get; set; }
		public int? StatusId { get; set; }
		public Status Status { get; set; }
		public int SchoolClassId { get; set; }
		public SchoolClass SchoolClass { get; set; }
	}
}
