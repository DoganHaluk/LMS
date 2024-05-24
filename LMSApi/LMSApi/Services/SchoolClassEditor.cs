using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;

namespace LMSApi.Services
{
    public class SchoolClassEditor
	{
		private readonly SchoolClassService _schoolClassService;
		private readonly CoachSchoolClassService _coachSchoolClassService;
		private readonly CoachService _coachService;
		//private readonly HttpContext _httpContext;

		public SchoolClassEditor(SchoolClassService schoolClassService, /*IHttpContextAccessor httpContextAccessor,*/ CoachSchoolClassService coachSchoolClassService,CoachService coachService)
		{
			_schoolClassService = schoolClassService;
			_coachSchoolClassService = coachSchoolClassService;
			_coachService = coachService;
			//_httpContext = httpContextAccessor.HttpContext;
		}


		public List<SchoolClass> GetSchoolClasses()
		{
			return _schoolClassService.GetSchoolClasses();
		}

		public List<InputError> ValidateUserClassOverview(int id)
		{
			List<InputError> errors = new List<InputError>();
			//var claim = _httpContext.User.Claims.First(c => c.Type == "userId");
			//int tokenId = Convert.ToInt32(claim.Value);
			//InputError ownerError = InputError.CheckOwner(id, tokenId);
			//if (ownerError != null)
			//{
			//	errors.Add(ownerError);
			//}
			return errors;
		}

		public SchoolClass GetSchoolClassOverview(int id)
		{
			return _schoolClassService.GetSchoolClassOverview(id);
		}

		public SchoolClass GetSchoolClassById(int id)
		{
			return _schoolClassService.GetSchoolClassById(id);
		}

		public List<InputError> ValidateSchoolClassCreation(CreateSchoolClassDto schoolClassDto)
		{
			List<InputError> errors = new List<InputError>();
			InputError nameError = InputError.CheckName(schoolClassDto.SchoolClassName);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			var schoolClass = _schoolClassService.GetSchoolClassByName(schoolClassDto.SchoolClassName);
			if (schoolClass != null)
			{
				InputError sameNameError = InputError.CheckExistingName(schoolClassDto.SchoolClassName, schoolClass.SchoolClassName);
				if (sameNameError != null)
				{
					errors.Add(sameNameError);
				}
			}
			var coach = _coachService.GetCoach(schoolClassDto.CoachId);
			if (coach == null) 
			{
				errors.Add(InputError.CheckCoach());
			}
			return errors;
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

		public List<InputError> ValidateSchoolClassEdition(int id, EditSchoolClassDto editSchoolClassDto)
		{
			List<InputError> errors = new List<InputError>();
			var schoolClass = _schoolClassService.GetSchoolClassById(id);
			if (schoolClass == null)
			{
				errors.Add(InputError.CheckSchoolClass());
			}
			InputError nameError = InputError.CheckName(editSchoolClassDto.SchoolClassName);
            if ( nameError != null)
            {
				errors.Add(nameError);
            }
			return errors;
        }

		public SchoolClass EditSchoolClassName(int id,SchoolClass schoolClass)
		{
			schoolClass.SchoolClassId = id;
			return _schoolClassService.UpdateSchoolClassName(schoolClass);
		}
		


		

		
	}
}
