using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CourseOverview
	{
		[Inject]
		private CourseService _courseService {  get; set; }

		[SupplyParameterFromQuery]
		public int CourseId { get; set; }

		[SupplyParameterFromQuery]
		public int UserId { get; set; }

		private CourseOverviewDto Course {  get; set; }

		CurrentUser User { get; set; }

		protected override async Task OnInitializedAsync()
		{
			User = await _authentication.GetUserAsync();
			Course = await _courseService.GetCourseOverview(CourseId);
		}


	}
}
