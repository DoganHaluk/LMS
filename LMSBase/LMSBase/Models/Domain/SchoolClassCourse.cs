using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Domain
{
	public class SchoolClassCourse
	{
		public int SchoolClassCourseId {  get; set; }
		public int? StatusId { get; set; }
		public Status Status { get; set; }
		public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
