using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
	public class CreateSchoolClassCourseDto
	{
		public int SchoolClassId {  get; set; }
		public List<int> CourseIds {  get; set; }
	}
}
