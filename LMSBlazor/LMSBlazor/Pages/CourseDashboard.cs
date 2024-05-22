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

		private List<CourseDto> Courses { get; set; }

		private List<SchoolClassSummaryDto> SchoolClasses { get; set; }

		private CreateSchoolClassCourseDto? CreateSchoolClassCourseDto { get; set; }


		protected override async Task OnInitializedAsync()
		{
			Courses = new List<CourseDto>();
			SchoolClasses = new List<SchoolClassSummaryDto>();
			Courses = await _courseService.GetCourses();
			SchoolClasses = await _schoolClassService.GetAllSchoolClasses();
		}

		public async Task CreateSchoolClassCourses()
		{
			await _schoolClassCourseService.CreateSchoolClassCourses(CreateSchoolClassCourseDto);
		}
	}
}
