using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos
{
	public class CreateCourseDto
	{
		public int CourseId {get; set;}
		public string CourseName { get; set;}
		public int SchoolClassId { get; set; }
	}
}
