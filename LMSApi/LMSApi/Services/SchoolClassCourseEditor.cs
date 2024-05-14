using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;

namespace LMSApi.Services
{
	public class SchoolClassCourseEditor
	{
		private readonly SchoolClassCourseService _schoolClassCourseService;

		public SchoolClassCourseEditor(SchoolClassCourseService schoolClassCourseService)
		{
			_schoolClassCourseService = schoolClassCourseService;
		}

		public void CreateSchoolClassCourse(int schoolClassId, List<int> courseIds)
		{
			foreach (int courseId in courseIds)
			{
				SchoolClassCourse schoolClassCourse = new SchoolClassCourse()
				{
					CourseId = courseId,
					SchoolClassId = schoolClassId,
					StatusId = 1
				};
				_schoolClassCourseService.CreateSchoolClassCourse(schoolClassCourse);
			}
		}
	}
}
