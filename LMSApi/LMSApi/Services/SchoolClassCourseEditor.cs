using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using LMSBase.Models.Dtos.Request;

namespace LMSApi.Services
{
	public class SchoolClassCourseEditor
	{
		private readonly SchoolClassCourseService _schoolClassCourseService;
		private readonly SchoolClassService _schoolClassService;
		private readonly CourseService _courseService;
		private readonly LMSDbContext _context;

		public SchoolClassCourseEditor(SchoolClassCourseService schoolClassCourseService,SchoolClassService schoolClassService, CourseService courseService,LMSDbContext context)
		{
			_schoolClassCourseService = schoolClassCourseService;
			_schoolClassService = schoolClassService;
			_courseService = courseService;
			_context = context;
		}

		public List<int> CheckSchoolClassCourses(int schoolClassId)
		{			
			return _schoolClassCourseService.GetSchoolClassCoursesWithSchoolClassId(schoolClassId);			
		}

		public List<InputError> ValidateAddCourses(CreateSchoolClassCourseDto schoolClassCourseDto)
		{
			List<InputError> errors = new List<InputError>();
			var schoolClass = _schoolClassService.GetSchoolClassById(schoolClassCourseDto.SchoolClassId);
			if (schoolClass == null)
			{
				errors.Add(InputError.CheckSchoolClass());
			}
			foreach(var courseId in schoolClassCourseDto.CourseIds)
			{
				var addCourse = _courseService.GetCourseById(courseId);
				if (addCourse == null)
				{
					errors.Add(InputError.CheckCourse());
				}
				var checkSchoolClassCourse = _schoolClassCourseService.GetSchoolClassCourseWithClassAndCourseId(courseId, schoolClassCourseDto.SchoolClassId);
				if (checkSchoolClassCourse != null)
				{
					errors.Add(InputError.CheckSchoolClassCourse());
				}
			}
			return errors;
		}

		public List<SchoolClassCourse> CreateSchoolClassCourse(CreateSchoolClassCourseDto createSchoolClassCourseDto)
		{
			var schoolClass = _schoolClassService.GetSchoolClassOverview(createSchoolClassCourseDto.SchoolClassId);
			schoolClass.SchoolClassCourses = new List<SchoolClassCourse>();
			foreach (int courseId in createSchoolClassCourseDto.CourseIds)
			{
				SchoolClassCourse schoolClassCourse = new SchoolClassCourse()
				{
					CourseId = courseId,
					SchoolClassId = createSchoolClassCourseDto.SchoolClassId,
					StatusId = 1
				};
				schoolClass.SchoolClassCourses.Add(_schoolClassCourseService.CreateSchoolClassCourse(schoolClassCourse));
			}
			//_context.ChangeTracker.DetectChanges();
			//var log = _context.ChangeTracker.DebugView.LongView;
			return schoolClass.SchoolClassCourses;
		}

		public void DeleteSchoolClassCourse(int id)
		{
			_schoolClassCourseService.DeleteSchoolClassCourse(id);
		}
	}
}
