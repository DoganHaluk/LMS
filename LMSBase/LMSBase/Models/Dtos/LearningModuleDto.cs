using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos
{
	public class LearningModuleDto
	{
		public int LearningModuleId { get; set; }
		public string ModuleName { get; set; }
		public int? ParentId { get; set; }
		public int? StatusId { get; set; }
		public int CourseId { get; set; }
	}
}
