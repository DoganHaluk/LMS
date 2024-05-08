using LMSApi.Configuration;
using LMSBase.Models.Domain;
using System.Runtime.InteropServices;

namespace LMSApi.Services
{
	public class CoachSchoolClassService
	{
		private readonly LMSDbContext _context;

		public CoachSchoolClassService(LMSDbContext context)
		{
			_context = context;
		}

		public List<CoachSchoolClass> GetCoachSchoolClasses()
		{
			return _context.CoachSchoolClasses.ToList();
		}

		public CoachSchoolClass GetCoachSchoolClass(int id)
		{
			return _context.CoachSchoolClasses.Find(id);
		}

		public CoachSchoolClass CreateCoachSchoolClass(CoachSchoolClass coachSchoolClass)
		{
			_context.CoachSchoolClasses.Add(coachSchoolClass);
			_context.SaveChanges();
			return coachSchoolClass;
		}



	}
}
