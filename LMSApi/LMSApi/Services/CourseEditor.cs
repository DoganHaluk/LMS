using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;

namespace LMSApi.Services
{
    public class CourseEditor
	{
		private readonly CourseService _courseService;

		public CourseEditor(CourseService courseService)
		{
			_courseService = courseService;
		}

		public List<InputError> ValidateUserCourseOverview(int id)
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


		public Course GetCourseById(int id)
		{
			return _courseService.GetCourseById(id);
		}



		public List<InputError> ValidateCourseCreation(CreateCourseDto createCourseDto)
		{
			List<InputError> errors = new List<InputError>();
			InputError nameError = InputError.CheckName(createCourseDto.CourseName);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			var newCourse = _courseService.GetCourseByName(createCourseDto.CourseName);
            if (newCourse != null)
            {
				InputError sameNameError = InputError.CheckExistingName(createCourseDto.CourseName, newCourse.CourseName);
				if (sameNameError != null)
				{
					errors.Add(sameNameError);
				}
			}
			return errors;
		}

		public Course CreateCourse(CreateCourseDto createCourseDto)
		{
			Course course = new Course()
			{
				CourseName = createCourseDto.CourseName,
			};
			return _courseService.CreateCourse(course);			 
		}

		public List<InputError> ValidateCourseEdition(int id,CreateCourseDto createCourseDto)
		{
			List<InputError> errors = new List<InputError>();
			var checkCourse = _courseService.GetCourseById(id);
			if (checkCourse == null)
			{
				errors.Add(InputError.CheckCourse());
			}
			InputError nameError = InputError.CheckName(createCourseDto.CourseName);
			if (nameError != null)
			{
				errors.Add(nameError);
			}
			return errors;
		}


		public Course UpdateCourseName(int id, CreateCourseDto courseDto)
		{
			return _courseService.UpdateCourseName(id, courseDto.CourseName);
		}
	}
}
