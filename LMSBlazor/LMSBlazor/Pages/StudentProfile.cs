using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class StudentProfile
	{
		[Inject]
		StudentService _studentService { get; set; }

		[SupplyParameterFromQuery]
		public int UserId { get; set; }

		StudentSummaryDto? Student {  get; set; } 

		CurrentUser User { get; set; }

		protected override async Task OnParametersSetAsync()
		{
			await UpdatePageAsync();
		}

		protected override async Task OnInitializedAsync()
		{
			await UpdatePageAsync();
		}

		private async Task UpdatePageAsync()
		{
			User = await _authenticationService.GetUserAsync();
			Student = await _studentService.GetStudentProfile(UserId);
		}

		private void NavigateToEdit()
		{
			_navigation.NavigateTo($"/editstudentprofile?UserId={UserId}");
		}

		private void NavigateToClass()
		{
			_navigation.NavigateTo($"/classoverview?UserId={UserId}&SchoolClassId={Student.SchoolClass.SchoolClassId}");
		}
	}
}
