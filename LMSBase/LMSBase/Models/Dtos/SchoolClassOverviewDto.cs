using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos
{
    public class SchoolClassOverviewDto
	{
		public int SchoolClassId { get; set; }
		public string SchoolClassName { get; set; }

		public List<StudentForOverviewDto> Students { get; set; }

		public List<CoachSchoolClassDto> CoachSchoolClasses { get; set; }

		public List<CoursesFromSchoolClassCoursesDto> SchoolClassCourses { get; set; }
	}
}
