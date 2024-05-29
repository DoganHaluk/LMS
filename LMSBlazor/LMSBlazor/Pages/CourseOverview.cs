using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Utilities;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class CourseOverview
	{
		[SupplyParameterFromQuery]
		public int CourseId { get; set; }

		[SupplyParameterFromQuery]
		public int UserId { get; set; }

		[SupplyParameterFromQuery]

		public int SchoolClassId { get; set; }

		private CourseOverviewDto Course { get; set; }

		private LearningModuleOverviewDto Module { get; set; }

		private LearningModuleOverviewDto Submodule { get; set; }

		private CreateLearningModuleDto NewModule { get; set; }

		private CreateCodelabDto NewCodelab { get; set; }

		private List<UpdateStatusCodelabDto> Statuses {  get; set; }

		private List<StudentCodelabSummaryDto> StudentCodelabs {  get; set; }

		private List<InputError> Errors {  get; set; }

		private CurrentUser User { get; set; }

		protected override async Task OnInitializedAsync()
		{
			User = await _stateContainer.GetUserAsync();
			Course = await _courseService.GetCourseOverview(CourseId);
			if (User.Role == "Student")
			{
				Statuses = await _studentCodelabService.GetStatuses();
				StudentCodelabs = await _studentCodelabService.GetStudentCodelabs(UserId);
			}			
		}

		//COACH VERSION

		public LearningModuleOverviewDto ChangeEditModule(int id)
		{
			Module = Course.Modules.Where(m => m.LearningModuleId == id).FirstOrDefault();
			Module.Edit = true;
			return Module;
		}

		public LearningModuleOverviewDto ChangeEditSubmodule(int id)
		{
			List<LearningModuleOverviewDto> submodules = new List<LearningModuleOverviewDto>();
			submodules = Course.Modules.SelectMany(m => m.SubModules).ToList();
			Submodule = submodules.Where(s => s.LearningModuleId == id).FirstOrDefault();
			Submodule.Edit = true;
			return Submodule;
		}

		public async Task EditModuleName()
		{
			Errors = await _learningModuleService.EditModuleName(Module.LearningModuleId, Module);
			if (Errors == null)
			{
				Module.Edit = false;
				await ReloadCourseAsync();
			}
		}

		public async Task EditSubmoduleName()
		{
			Errors = await _learningModuleService.EditModuleName(Submodule.LearningModuleId, Submodule);
			if (Errors == null)
			{
				Submodule.Edit = false;
				await ReloadCourseAsync();
			}
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
			Errors = await _learningModuleService.CreateModule(NewModule);
			if (Errors == null)
			{
				NewModule = null;
				await ReloadCourseAsync();
			}
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
			Errors = await _codelabService.CreateCodelab(NewCodelab);
			if (Errors == null)
			{
				NewCodelab = null;
				Course = await _courseService.GetCourseOverview(CourseId);
			}

		}

		public async Task DeleteModule(int id)
		{
			var module = Course.Modules.Where(m => m.LearningModuleId == id).FirstOrDefault();
			if (module.SubModules.Count == 0 && module.Codelabs.Count == 0)
			{
				await _learningModuleService.DeleteModule(id);
			}
			await ReloadCourseAsync();
		}

		public async Task DeleteSubmodule(int id)
		{
			var submodules = Course.Modules.SelectMany(m => m.SubModules).ToList();
			var submodule = submodules.Where(s => s.LearningModuleId == id).FirstOrDefault();
			if(submodule.Codelabs.Count == 0)
			{
				await _learningModuleService.DeleteModule(id);
			}
			await ReloadCourseAsync();
		}

		public void NavigateToProgression(int moduleId)
		{
			_navigation.NavigateTo($"/progressions?SchoolClassId={SchoolClassId}&ModuleId={moduleId}");
		}

		public async Task ReloadCourseAsync()
		{
			Course = await _courseService.GetCourseOverview(CourseId);
		}
	}
}
