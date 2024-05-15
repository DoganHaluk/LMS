using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
    public class SchoolClassOverviewDto
    {
        public int SchoolClassId { get; set; }
        public string SchoolClassName { get; set; }

        public List<StudentSummaryDto> Students { get; set; }

        public List<CoachSchoolClassDto> CoachSchoolClasses { get; set; }

        public List<CoursesFromSchoolClassCoursesDto> SchoolClassCourses { get; set; }
    }
}
