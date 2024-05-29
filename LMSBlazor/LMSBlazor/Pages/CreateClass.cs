using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Utilities;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CreateClass
	{
		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		private string Name { get; set; } = "";

		private List<SchoolClassSummaryDto> SchoolClasses {  get; set; }

		private CreateSchoolClassDto NewClass {  get; set; }

		private List<InputError> Errors { get; set; }

		protected override async Task OnInitializedAsync()
		{
			SchoolClasses = new List<SchoolClassSummaryDto>();
			SchoolClasses = await _schoolClassService.GetAllSchoolClasses();
		}

		public async Task CreateSchoolClass()
		{
			NewClass = new CreateSchoolClassDto()
			{
				SchoolClassName = Name,
				CoachId = UserId
			};
			Errors = await _schoolClassService.CreateSchoolClass(NewClass);
			if (Errors == null)
			{
				_navigation.NavigateTo($"/coachprofile?UserId={UserId}");
			}
		}

		private void NavigateToCoachProfile()
		{
			_navigation.NavigateTo($"/coachprofile?UserId={UserId}");
		}

	}
}
