using LMSApi.Configuration;
using LMSBase.Models.Domain;

namespace LMSApi.Services
{
	public class StatusService
	{
		private readonly LMSDbContext _context;

		public StatusService(LMSDbContext context)
		{
			_context = context;
		}

		public List<Status> GetAllStatuses()
		{
			return _context.Statuses.ToList();
		}
	}
}
