using LMSApi.Configuration;
using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class CodelabService
	{
		private readonly LMSDbContext _context;

		public CodelabService(LMSDbContext context)
		{
			_context = context;
		}

		public List<Codelab> GetAllCodelabs()
		{
			return _context.Codelabs.ToList();
		}

		public Codelab GetCodelabById(int id) 
		{
			return _context.Codelabs.Where(c=>c.CodelabId==id).Include(c=>c.LearningModule).FirstOrDefault();
		}

		public Codelab CreateCodelab(Codelab codelab)
		{
			_context.Codelabs.Add(codelab);
			_context.SaveChanges();
			return codelab;
		}

		public Codelab UpdateCodelab(Codelab codelab)
		{
			var updated = _context.Codelabs.Find(codelab.CodelabId);
			updated = codelab;
			_context.SaveChanges();
			return updated;
		}
	}
}
