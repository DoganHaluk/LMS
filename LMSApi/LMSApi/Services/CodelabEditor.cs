using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMSApi.Services
{
	public class CodelabEditor
	{
		private readonly CodelabService _codelabService;


		public CodelabEditor(CodelabService codelabService)
		{
			_codelabService = codelabService;
		}

		public List<Codelab> GetAllCodelabs()
		{
			return _codelabService.GetAllCodelabs();
		}

		public Codelab GetCodelabById(int id)
		{
			return _codelabService.GetCodelabById(id);
		}

		public Codelab CreateCodelab(Codelab codelab)
		{
			return _codelabService.CreateCodelab(codelab);
		}

		public Codelab UpdateCodelab(EditCodelabDto editCodelabDto)
		{
			var update = _codelabService.GetCodelabById(editCodelabDto.CodelabId);
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

	}
}
