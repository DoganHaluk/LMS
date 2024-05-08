using LMSApi.Configuration;
using LMSBase.Models.Domain;

namespace LMSApi.Services
{
	public class CoachServices
	{
		private readonly LMSDbContext _context;

		public CoachServices(LMSDbContext context)
		{
			_context = context;
		}

		public List<Coach> GetCoaches()
		{
			return _context.Coaches.ToList();
		}

		public Coach GetCoach(int id)
		{
			return _context.Coaches.Find(id);
		}

		public Coach CreateCoach(Coach coach)
		{
			_context.Coaches.Add(coach);
			_context.SaveChanges();
			return coach;
		}


	}
}
