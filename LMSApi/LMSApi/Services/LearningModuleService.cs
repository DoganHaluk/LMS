using LMSApi.Configuration;
using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class LearningModuleService
	{
		private readonly LMSDbContext _context;

		public LearningModuleService(LMSDbContext context)
		{
			_context = context;
		}

		public List<LearningModule> GetLearningModules()
		{
			return _context.LearningModules
				.Include(m => m.SubModules)
				.Include(m => m.Course)
				.ToList();
		}

		public LearningModule CreateLearningModule(LearningModule learningModule)
		{
			_context.LearningModules.Add(learningModule);
			_context.SaveChanges();
			return learningModule;
		}

		public LearningModule UpdateLearningModule(LearningModule learningModule)
		{
			var newLearningModule = _context.LearningModules.Find(learningModule.LearningModuleId);
			newLearningModule = learningModule;
			_context.SaveChanges();
			return newLearningModule;
		}
	}
}
