using LMSBase.Models.Utilities;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using AutoMapper;

namespace LMSApi.Services
{
    public class CourseEditor
	{
		private readonly CourseService _courseService;
		private readonly IMapper _mapper;

		public CourseEditor(CourseService courseService,IMapper mapper)
		{
			_courseService = courseService;
			_mapper = mapper;
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

		public List<CourseDto> GetCourses()
		{
			List<CourseDto> courses = new List<CourseDto>();
			List<Course> getCourses = _courseService.GetCourses();
			foreach (var course in getCourses)
			{
				CourseDto newCourse = new CourseDto()
				{
					CourseId = course.CourseId,
					CourseName = course.CourseName,
					Modules = _mapper.Map<List<LearningModuleOverviewDto>>(course.Modules)
				};
				courses.Add(newCourse);
			}
			return courses;
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
