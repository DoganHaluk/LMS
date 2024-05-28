using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CoachProfile
	{
		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		private CoachSummaryDto? Coach {  get; set; }

		CurrentUser User { get; set; }

		protected override async Task OnInitializedAsync()
		{
			User = await _stateContainer.GetUserAsync();
			Coach = await _coachService.GetCoachProfileAsync(UserId);
		}

		public async Task NavigateToCreateClass()
		{
			_navigation.NavigateTo($"/createclass?UserId={UserId}");
		}

		public async Task NavigateToCourseDashboard()
		{
			_navigation.NavigateTo($"/coursedashboard?UserId={UserId}");
		}
	}
}
