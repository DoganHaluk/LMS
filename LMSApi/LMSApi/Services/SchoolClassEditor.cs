using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;

namespace LMSApi.Services
{
    public class SchoolClassEditor
	{
		private readonly SchoolClassService _schoolClassService;
		private readonly CoachSchoolClassService _coachSchoolClassService;

		public SchoolClassEditor(SchoolClassService schoolClassService, CoachSchoolClassService coachSchoolClassService)
		{
			_schoolClassService = schoolClassService;
			_coachSchoolClassService = coachSchoolClassService;
		}

		public SchoolClass CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
		{
			SchoolClass schoolClass = new SchoolClass()
			{
				SchoolClassName = createSchoolClassDto.SchoolClassName,
			};
			var newSchoolClass = _schoolClassService.CreateSchoolClass(schoolClass);

			CoachSchoolClass coachSchoolClass = new CoachSchoolClass()
			{
				CoachId = createSchoolClassDto.CoachId,
				SchoolClassId = newSchoolClass.SchoolClassId
			};
			_coachSchoolClassService.CreateCoachSchoolClass(coachSchoolClass);
			return newSchoolClass;
		}

		public List<SchoolClass> GetSchoolClasses()
		{
			return _schoolClassService.GetSchoolClasses();
		}

		public SchoolClass GetSchoolClassOverview(int id)
		{	
			return _schoolClassService.GetSchoolClassOverview(id);			
		}

		public SchoolClass GetSchoolClassById(int id)
		{
			return _schoolClassService.GetSchoolClassById(id);
		}
	}
}
