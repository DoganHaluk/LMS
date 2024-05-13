using AutoMapper;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;

namespace LMSApi.Configuration
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration() 
		{
			CreateMap<Coach,GetCoachProfileDto>();
			CreateMap<SchoolClass,SchoolClassOverviewDto>();
			CreateMap<SchoolClass,SchoolClassForListDto>();
			CreateMap<Student,StudentForOverviewDto>();
			CreateMap<CoachSchoolClass,CoachFromCoachSchoolClassDto>();
			CreateMap<SchoolClassCourse,CoursesFromSchoolClassCoursesDto>();
			CreateMap<Course,CourseForOverviewDto>();
			CreateMap<CreateStudentDto, Student>();
			CreateMap<Student,GetStudentDto>();
			CreateMap<StudentForClassUpdate, Student>();
		}
	}
}
