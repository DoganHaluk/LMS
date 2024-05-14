using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using LMSBase.Models.Dtos.Request;

namespace LMSApi.Services
{
	public class SchoolClassCourseEditor
	{
		private readonly SchoolClassCourseService _schoolClassCourseService;

		public SchoolClassCourseEditor(SchoolClassCourseService schoolClassCourseService)
		{
			_schoolClassCourseService = schoolClassCourseService;
		}

		public List<SchoolClassCourse> CreateSchoolClassCourse(CreateSchoolClassCourseDto createSchoolClassCourseDto)
		{
			List<SchoolClassCourse> schoolClassCourses = new List<SchoolClassCourse>();
			foreach (int courseId in createSchoolClassCourseDto.CourseIds)
			{
				SchoolClassCourse schoolClassCourse = new SchoolClassCourse()
				{
					CourseId = courseId,
					SchoolClassId = createSchoolClassCourseDto.SchoolClassId,
					StatusId = 1
				};
				schoolClassCourses.Add(_schoolClassCourseService.CreateSchoolClassCourse(schoolClassCourse));
			}
			return schoolClassCourses;
		}
	}
}
