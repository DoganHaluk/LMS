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
		}
	}
}
