namespace LMSBase.Models.Domain
{
	public class SchoolClass
	{
		public int SchoolClassId { get; set; }
		public string SchoolClassName { get; set; }
		public List<SchoolClassCourse> SchoolClassCourses { get; set; }
		public List<Student> Students { get; set; }
		public int? StatusId { get; set; }
		public Status Status { get; set; }
		public List<CoachSchoolClass> CoachSchoolClasses { get; set; }
		//public List<Coach> Coaches { get; set; }
	}
}
