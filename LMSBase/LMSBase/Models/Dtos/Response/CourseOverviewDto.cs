using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class CourseOverviewDto
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public List<LearningModuleOverviewDto> Modules { get; set; }

		public Status Status { get; set; }
	}
}
