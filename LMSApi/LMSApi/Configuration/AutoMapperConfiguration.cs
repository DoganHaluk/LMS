using AutoMapper;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using LMSBase.Models.Dtos.Request;
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
			CreateMap<Student,StudentSummaryDto>();
			CreateMap<CoachSchoolClass,CoachSchoolClassDto>();
			CreateMap<SchoolClassCourse,CoursesFromSchoolClassCoursesDto>();
			CreateMap<Course,CourseForOverviewDto>();
			CreateMap<CreateStudentDto, Student>();
			CreateMap<Student,StudentSummaryDto>();
			CreateMap<EditStudentProfileDto, Student>();
			CreateMap<SchoolClassCourse, SchoolClassCourseDto>();
			CreateMap<Course, CourseSummaryDto>();
			CreateMap<Status, StatusDto>();
			CreateMap<Course, CourseDto>();
			CreateMap<LearningModule, LearningModuleDto>();
			CreateMap<CreateCoachDto, Coach>();
			CreateMap<Codelab, CodelabSummaryDto>();
			CreateMap<CreateCodelabDto, Codelab>();
		}
	}
}
