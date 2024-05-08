using LMSApi.Configuration;
using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class SchoolClassService
	{
		private readonly LMSDbContext _context;

		public SchoolClassService(LMSDbContext context)
		{
			_context = context;
		}

		public List<SchoolClass> GetSchoolClasses()
		{
			return _context.SchoolClasses.ToList();
		}

		public SchoolClass GetSchoolClassOverview(int id)
		{
			return _context.SchoolClasses.Where(x => x.SchoolClassId == id).Include(x=>x.Students).Include(x=>x.CoachSchoolClasses).ThenInclude(c=>c.Coach).FirstOrDefault();
		}

		public SchoolClass CreateSchoolClass(SchoolClass schoolClass)
		{
			_context.SchoolClasses.Add(schoolClass);
			_context.SaveChanges();
			return schoolClass;
		}

		public SchoolClass UpdateStatusToDone(int schoolClassId) 
		{
			var schoolClass = _context.SchoolClasses.Find(schoolClassId);

			schoolClass.StatusId = 8;

			_context.SaveChanges();
			return schoolClass;
		}

		public void DeleteSchoolClass(int schoolClassId)
		{
			var schoolClass = _context.SchoolClasses.Find(schoolClassId);

			_context.SchoolClasses.Remove(schoolClass);

			_context.SaveChanges();
		}


	}
}
