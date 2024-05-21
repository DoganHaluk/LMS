using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CreateClass
	{
		[Inject]
		private SchoolClassService _schoolClassService {  get; set; }

		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		private string Name { get; set; } = "";

		private CreateSchoolClassDto NewClass {  get; set; }

		private SchoolClassSummaryDto CreatedClass {  get; set; }


		public async Task CreateSchoolClass()
		{
			NewClass = new CreateSchoolClassDto()
			{
				SchoolClassName = Name,
				CoachId = UserId
			};
			CreatedClass = new SchoolClassSummaryDto();
			CreatedClass = await _schoolClassService.CreateSchoolClass(NewClass);
			if (CreatedClass != null)
			{
				_navigation.NavigateTo($"/classoverview?UserId={UserId}&SchoolClassId={CreatedClass.SchoolClassId}");
			}
		}

		private void NavigateToCoachProfile()
		{
			_navigation.NavigateTo($"/coachprofile?UserId={UserId}");
		}

	}
}
