using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMSApi.Services
{
	public class CodelabEditor
	{
		private readonly CodelabService _codelabService;
		private readonly LearningModuleService _learningModuleService;


		public CodelabEditor(CodelabService codelabService, LearningModuleService learningModuleService)
		{
			_codelabService = codelabService;
			_learningModuleService = learningModuleService;
		}

		public List<Codelab> GetAllCodelabs()
		{
			return _codelabService.GetAllCodelabs();
		}

		public Codelab GetCodelabById(int id)
		{
			return _codelabService.GetCodelabById(id);
		}


		public List<InputError> ValidateCodelabCreation(CreateCodelabDto createCodelabDto)
		{
			List<InputError> errors = new List<InputError>();
			InputError nameError = InputError.CheckName(createCodelabDto.Name);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			InputError descriptionError = InputError.CheckDescription(createCodelabDto.Description);
			if (descriptionError != null)
			{
				errors.Add(descriptionError);
			}
			var checkModule = _learningModuleService.GetLearningModuleById(createCodelabDto.LearningModuleId);
			InputError moduleError = InputError.CheckLearningModule(checkModule);
			if (moduleError != null)
			{
				errors.Add(moduleError);
			}
			return errors;
		}

		public Codelab CreateCodelab(Codelab codelab)
		{
			return _codelabService.CreateCodelab(codelab);
		}

		public List<InputError> ValidateCodelabEdition(int id,EditCodelabDto editCodelabDto)
		{
			List<InputError> errors = new List<InputError>();
			var checkCodelab = _codelabService.GetCodelabById(id);
			InputError codelabError = InputError.CheckCodelab(checkCodelab);
            if (codelabError != null)
            {
				errors.Add(codelabError);
            }
			if (!editCodelabDto.Name.IsNullOrEmpty())
			{
				InputError nameError = InputError.CheckName(editCodelabDto.Name);
				if (nameError != null)
				{
					errors.Add(nameError);
				}
			}
			if (!editCodelabDto.Description.IsNullOrEmpty())
			{
				InputError descriptionError = InputError.CheckDescription(editCodelabDto.Description);
				if (descriptionError != null)
				{
					errors.Add(descriptionError);
				}
			}
			if (editCodelabDto.LearningModuleId > 0)
			{
				var checkModule = _learningModuleService.GetLearningModuleById(editCodelabDto.LearningModuleId);
				InputError moduleError = InputError.CheckLearningModule(checkModule);
				if (moduleError != null)
				{
					errors.Add(moduleError);
				}
			}
			return errors;
		}

		public Codelab UpdateCodelab(int id, EditCodelabDto editCodelabDto)
		{
			var update = _codelabService.GetCodelabById(id);
			if (editCodelabDto.Name != update.Name && !editCodelabDto.Name.IsNullOrEmpty())
			{
				update.Name = editCodelabDto.Name;
			}
			if (editCodelabDto.Description != update.Description && !editCodelabDto.Description.IsNullOrEmpty())
			{
				update.Description = editCodelabDto.Description;
			}
			if (editCodelabDto.LearningModuleId != update.LearningModuleId && editCodelabDto.LearningModuleId > 0)
			{
				update.LearningModuleId = editCodelabDto.LearningModuleId;
			}

			return _codelabService.UpdateCodelab(update);
		}

		public void DeleteCodelab(int codelabId)
		{
			_codelabService.DeleteCodelab(codelabId);
		}

	}
}
