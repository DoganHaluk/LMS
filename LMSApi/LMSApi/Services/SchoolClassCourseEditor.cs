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

		public SchoolClassCourseEditor(SchoolClassCourseService schoolClassCourseService,SchoolClassService schoolClassService, CourseService courseService)
		{
			_schoolClassCourseService = schoolClassCourseService;
			_schoolClassService = schoolClassService;
			_courseService = courseService;
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
			List<SchoolClassCourse> schoolClassCourses = new List<SchoolClassCourse>();
			foreach (int courseId in createSchoolClassCourseDto.CourseIds)
			{
				SchoolClassCourse schoolClassCourse = new SchoolClassCourse()
				{
					CourseId = courseId,
					SchoolClassId = createSchoolClassCourseDto.SchoolClassId,
					StatusId = 1
				};
				schoolClassCourses.Add(_schoolClassCourseService.CreateSchoolClassCourse(schoolClassCourse));
			}
			return schoolClassCourses;
		}

		public void DeleteSchoolClassCourse(int id)
		{
			_schoolClassCourseService.DeleteSchoolClassCourse(id);
		}
	}
}
