using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;

namespace LMSApi.Services
{
	public class CourseEditor
	{
		private readonly CourseService _courseService;
		private readonly SchoolClassCourseService _schoolClassCourseService;

		public CourseEditor(CourseService courseService, SchoolClassCourseService schoolClassCourseService)
		{
			_courseService = courseService;
			_schoolClassCourseService = schoolClassCourseService;
		}

		public Course CreateCourse(CreateCourseDto createCourseDto)
		{
			Course course = new Course()
			{
				CourseName = createCourseDto.CourseName,
			};
			var newCourse = _courseService.CreateCourse(course);

			SchoolClassCourse schoolClassCourse = new SchoolClassCourse()
			{
				CourseId = newCourse.CourseId,
				SchoolClassId = createCourseDto.SchoolClassId,
				StatusId = 1
			};
			_schoolClassCourseService.CreateSchoolClassCourse(schoolClassCourse);
			return newCourse;
		}

		public Course UpdateCourseName(int id, CourseNameDto courseDto)
		{
			return _courseService.UpdateCourseName(id, courseDto.CourseName);
		}
	}
}
