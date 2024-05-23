using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
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

		private LearningModuleOverviewDto Module {  get; set; }

		private CodelabSummaryDto Codelab {  get; set; }

		private CreateLearningModuleDto NewModule { get; set; }

		private CreateCodelabDto NewCodelab { get; set; }

		CurrentUser User { get; set; }

		protected override async Task OnInitializedAsync()
		{
			User = await _authentication.GetUserAsync();
			Course = await _courseService.GetCourseOverview(CourseId);
		}

		public LearningModuleOverviewDto EditChange(int id)
		{
			Module = Course.Modules.Where(m=>m.LearningModuleId ==  id).FirstOrDefault();
			Module.Edit = true;
			return Module;
		}

		public async Task EditModuleName()
		{
			await _learningModuleService.EditModuleName(Module.LearningModuleId, Module);
			Module.Edit = false;
			await _courseService.GetCourseOverview(CourseId);
		}

		public void AddModule(int id = 0)
		{
			NewModule = new CreateLearningModuleDto()
			{
				ModuleName = "",
				ParentId = id,
				CourseId = Course.CourseId,
				Edit = true
			};
		}

		public async Task CreateModule()
		{
			await _learningModuleService.CreateModule(NewModule);
			NewModule = null;
			await _courseService.GetCourseOverview(CourseId);
		}

		public void AddCodelab(int id)
		{
			NewCodelab = new CreateCodelabDto()
			{
				Name = "",
				Description = "",
				LearningModuleId = id,
				Edit = true
			};
		}

		public async Task CreateCodelab()
		{
			await _codelabService.CreateCodelab(NewCodelab);
			NewCodelab = null;
			await _courseService.GetCourseOverview(CourseId);
		}

		//public async Task DeleteModule(int id)
		//{
		//	await _learningModuleService.DeleteModule(id);
		//}
	}
}
