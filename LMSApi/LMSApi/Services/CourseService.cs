using LMSApi.Configuration;
using LMSBase.Models.Domain;

namespace LMSApi.Services
{
	public class CourseService
	{
		private readonly LMSDbContext _context;

		public CourseService(LMSDbContext context)
		{
			_context = context;
		}

		
	}
}
