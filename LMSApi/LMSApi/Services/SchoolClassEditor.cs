using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;

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

		public CreateSchoolClassDto CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
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
			createSchoolClassDto.SchoolClassId = newSchoolClass.SchoolClassId;
			return createSchoolClassDto;
		}

		public List<ListSchoolClassesDto> GetSchoolClasses()
		{
			List<ListSchoolClassesDto> listSchoolClassesDtos = new List<ListSchoolClassesDto>();
			List<SchoolClass> schoolClasses = _schoolClassService.GetSchoolClasses();
			foreach (var schoolClass in schoolClasses)
			{
				ListSchoolClassesDto listSchoolClassesDto = new ListSchoolClassesDto()
				{
					SchoolClassId = schoolClass.SchoolClassId,
					SchoolClassName = schoolClass.SchoolClassName,
				};
				listSchoolClassesDtos.Add(listSchoolClassesDto);
			}
			return listSchoolClassesDtos;
		}

		public SchoolClassOverviewDto GetSchoolClassOverview(int id)
		{			
			SchoolClass schoolClass = _schoolClassService.GetSchoolClassOverview(id);

			SchoolClassOverviewDto schoolClassOverviewDto = new SchoolClassOverviewDto()
			{
				SchoolClassId = schoolClass.SchoolClassId,
				SchoolClassName = schoolClass.SchoolClassName,
			};
			foreach (var student in schoolClass.Students)
			{
				schoolClassOverviewDto.StudentsNames.Add(student.UserName);
			}
			foreach (var coach in schoolClass.CoachSchoolClasses)
			{
				schoolClassOverviewDto.CoachesNames.Add(coach.Coach.UserName);
			}
			return schoolClassOverviewDto;
		}
	}
}
