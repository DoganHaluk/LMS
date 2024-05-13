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

		public Course CreateCourse(CourseDto courseDto)
		{
			Course course = new Course()
			{
				CourseName = courseDto.CourseName,
			};
			return _courseService.CreateCourse(course);			 
		}

		public Course UpdateCourseName(int id, CourseDto courseDto)
		{
			return _courseService.UpdateCourseName(id, courseDto.CourseName);
		}
	}
}
