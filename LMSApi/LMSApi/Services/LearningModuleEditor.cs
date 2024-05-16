using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Headers;

namespace LMSApi.Services
{
    public class LearningModuleEditor
	{
		private readonly LearningModuleService _learningModuleService;
		private readonly CourseService _courseService;

		public LearningModuleEditor(LearningModuleService learningModuleService,CourseService courseService)
		{
			_learningModuleService = learningModuleService;
			_courseService = courseService;
		}


		public List<InputError> ValidateLearningModuleCreation(CreateLearningModuleDto createLearningModuleDto)
		{
			List<InputError> errors = new List<InputError>();
			InputError nameError = InputError.CheckName(createLearningModuleDto.ModuleName);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			var checkName = _learningModuleService.GetLearningModuleByName(createLearningModuleDto.ModuleName);
			InputError sameNameError = InputError.CheckExistingName(createLearningModuleDto.ModuleName, checkName.ModuleName);
			if (sameNameError != null)
			{
				errors.Add(sameNameError);
			}
			if (createLearningModuleDto.ParentId > 0)
			{
				var checkModule = _learningModuleService.GetLearningModuleById(createLearningModuleDto.ParentId);
				InputError moduleError = InputError.CheckLearningModule(checkModule);
				if (moduleError != null)
				{
					errors.Add(moduleError);
				}
			}
			var checkCourse = _courseService.GetCourseById(createLearningModuleDto.CourseId);
			if (checkCourse == null)
			{
				errors.Add(InputError.CheckCourse());
			}
			return errors;
		}


		public LearningModule CreateLearningModule(CreateLearningModuleDto learningModuleDto)
		{
			LearningModule learningModule = new LearningModule()
			{
				ModuleName = learningModuleDto.ModuleName,
				CourseId = learningModuleDto.CourseId,
				ParentId = learningModuleDto.ParentId>0? learningModuleDto.ParentId: null,				
			};
			return _learningModuleService.CreateLearningModule(learningModule);
		}


		public List<InputError> ValidateModuleEdition(int id, LearningModuleNameDto learningModuleNameDto)
		{
			List<InputError> errors = new List<InputError>();
			var checkModule = _learningModuleService.GetLearningModuleById(id);
			InputError moduleError = InputError.CheckLearningModule(checkModule);
			if (moduleError != null)
			{
				errors.Add(moduleError);
			}
			InputError nameError = InputError.CheckName(learningModuleNameDto.ModuleName);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			var nameModule = _learningModuleService.GetLearningModuleByName(learningModuleNameDto.ModuleName);
			InputError sameNameError = InputError.CheckExistingName(learningModuleNameDto.ModuleName,nameModule.ModuleName);
			if (sameNameError != null)
			{
				errors.Add(sameNameError);
			}
			return errors;
		}



		public LearningModule UpdateLearningModuleName(int id, LearningModuleNameDto learningModuleNameDto)
		{
			return _learningModuleService.UpdateLearningModuleName(id, learningModuleNameDto.ModuleName);
		}
	}
}
