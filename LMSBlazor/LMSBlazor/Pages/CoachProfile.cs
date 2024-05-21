using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CoachProfile
	{
		[Inject]
		CoachService _coachService { get; set; }

		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		private CoachSummaryDto Coach {  get; set; }

		User User { get; set; }

		protected override async Task OnInitializedAsync()
		{
			User = await _authenticationService.GetUserAsync();
			Coach = await _coachService.GetCoachProfileAsync(UserId);
		}

		public async Task NavigateToCreateClass()
		{
			_navigation.NavigateTo($"/createclass?UserId={UserId}");
		}
	}
}
