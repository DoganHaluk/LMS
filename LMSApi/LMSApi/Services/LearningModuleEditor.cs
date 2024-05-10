using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using System.Net.Http.Headers;

namespace LMSApi.Services
{
	public class LearningModuleEditor
	{
		private readonly LearningModuleService _learningModuleService;

		public LearningModuleEditor(LearningModuleService learningModuleService)
		{
			_learningModuleService = learningModuleService;
		}

		public LearningModule CreateLearningModule(LearningModuleDto learningModuleDto)
		{
			LearningModule learningModule = new LearningModule()
			{
				ModuleName = learningModuleDto.ModuleName,
				CourseId = learningModuleDto.CourseId,
				ParentId = learningModuleDto.ParentId,
				StatusId = learningModuleDto.StatusId is null ? 1 : learningModuleDto.StatusId,
			};
			return _learningModuleService.CreateLearningModule(learningModule);
		}

		public LearningModule UpdateLearningModule(int id, LearningModuleDto learningModuleDto)
		{
			LearningModule learningModule = new LearningModule()
			{
				LearningModuleId = id,
				ModuleName = learningModuleDto.ModuleName,
				CourseId = learningModuleDto.CourseId,
				ParentId = learningModuleDto.ParentId,
				StatusId = learningModuleDto.StatusId,
			};
			return _learningModuleService.UpdateLearningModule(learningModule);
		}
	}
}
