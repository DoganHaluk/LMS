using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CourseDashboard
	{
		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		List<CourseDto> Courses { get; set; }

		CourseDto Course { get; set; }

		CourseDto NewCourse { get; set; }


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
			_courseService.EditCourseName(Course.CourseId, Course);
			Course.Selected = false;
		}

		public async Task CreateNewCourse()
		{
			_courseService.CreateCourse(NewCourse);
			NewCourse.Selected = false;
			Courses = await _courseService.GetCourses();
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
