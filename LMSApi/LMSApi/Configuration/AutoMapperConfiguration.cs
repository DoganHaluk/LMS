using AutoMapper;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using LMSBase.Models.Dtos.Response;

namespace LMSApi.Configuration
{
    public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration() 
		{
			CreateMap<Coach,CoachSummaryDto>();
			CreateMap<SchoolClass,SchoolClassOverviewDto>();
			CreateMap<SchoolClass,SchoolClassSummaryDto>();
			CreateMap<Student,StudentForOverviewDto>();
			CreateMap<CoachSchoolClass,CoachSchoolClassDto>();
			CreateMap<SchoolClassCourse,CoursesFromSchoolClassCoursesDto>();
			CreateMap<Course,CourseForOverviewDto>();
			CreateMap<CreateStudentDto, Student>();
			CreateMap<Student,GetStudentDto>();
			CreateMap<StudentForClassUpdate, Student>();
			CreateMap<SchoolClassCourse, SchoolClassCourseDto>();
			CreateMap<Course, CourseSummaryDto>();
			CreateMap<Status, StatusDto>();
			CreateMap<Course, CourseDto>();
			CreateMap<LearningModule, LearningModuleDto>();
		}
	}
}
