using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class SchoolClassCourseDto
	{
		public int SchoolClassCourseId {  get; set; }
		public SchoolClassSummaryDto SchoolClass {  get; set; }
		public CourseOverviewDto Course {  get; set; }
		public StatusDto Status {  get; set; }
	}
}
