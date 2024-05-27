using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Utilities;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CourseDashboard
	{
		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		private List<CourseDto> Courses { get; set; }

		private CourseDto Course { get; set; }

		private CourseDto NewCourse { get; set; }

		private List<InputError> Errors { get; set; }


		protected override async Task OnInitializedAsync()
		{
			Courses = await _courseService.GetCourses();
		}

		public CourseDto ChangeEdit(int courseId)
		{
			Course = Courses.Where(c => c.CourseId == courseId).FirstOrDefault();
			Course.Selected = true;
			return Course;
		}

		public async Task EditCourseName()
		{
			Errors = await _courseService.EditCourseName(Course.CourseId, Course);
			if (Errors == null)
			{
				Course.Selected = false;
			}			
		}

		public async Task CreateNewCourse()
		{
			Errors = await _courseService.CreateCourse(NewCourse);
			if (Errors == null)
			{
				NewCourse.Selected = false;
				Courses = await _courseService.GetCourses();
			}			
		}


		public async Task DeleteCourse(int courseId)
		{
			var course = await _courseService.GetCourseOverview(courseId);
			if (course.Modules.Count == 0 && course != null)
			{
				await _courseService.DeleteCourse(courseId);
				Courses = await _courseService.GetCourses();
			}
		}

		public async Task CreateCourse()
		{
			NewCourse = new CourseDto();
			NewCourse.CourseName = "";
			NewCourse.Selected = true;
		}
	}
}
