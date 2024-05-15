using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;

namespace LMSApi.Services
{
    public class CourseEditor
	{
		private readonly CourseService _courseService;

		public CourseEditor(CourseService courseService)
		{
			_courseService = courseService;
		}

		public Course CreateCourse(CreateCourseDto createCourseDto)
		{
			Course course = new Course()
			{
				CourseName = createCourseDto.CourseName,
			};
			return _courseService.CreateCourse(course);			 
		}

		public Course UpdateCourseName(int id, CreateCourseDto courseDto)
		{
			return _courseService.UpdateCourseName(id, courseDto.CourseName);
		}
	}
}
