using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
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

		public LearningModule GetLearningModuleById(int id)
		{
			return _context.LearningModules.Find(id);
		}

		public LearningModule GetLearningModuleByName(string name)
		{
			return _context.LearningModules.Where(l => l.ModuleName == name).FirstOrDefault();
		}

		public LearningModule CreateLearningModule(LearningModule learningModule)
		{
			_context.LearningModules.Add(learningModule);
			_context.SaveChanges();
			return learningModule;
		}

		public LearningModule UpdateLearningModuleName(int id, string moduleName)
		{
			var newLearningModule = _context.LearningModules.Find(id);
			newLearningModule.ModuleName = moduleName;
			_context.SaveChanges();
			return newLearningModule;
		}
	}
}
