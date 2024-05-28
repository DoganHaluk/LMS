using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class Progressions
	{
		[SupplyParameterFromQuery]
		public int SchoolClassId { get; set; }

		[SupplyParameterFromQuery]
		public int ModuleId { get; set; }

		public LearningModuleDto LearningModuleDto { get; set; }

		public List<ProgressionDto> LabProgressions { get; set; }


		protected override async Task OnInitializedAsync()
		{
			LabProgressions = new List<ProgressionDto>();
			LabProgressions = await _studentcodelabService.GetProgressions(SchoolClassId, ModuleId);
			LearningModuleDto = new LearningModuleDto();
			LearningModuleDto = await _learningModuleService.GetModuleById(ModuleId);
		}

		public int GetValue(ProgressionDto progression)
		{
			return (100/progression.TotalCodelabs)*progression.FinishedCodelabs;
			
		}

	}
}
