using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class LearningModuleOverviewDto
	{
		public int LearningModuleId { get; set; }
		public string ModuleName { get; set; }

		public int ParentId { get; set; }
		public List<LearningModuleOverviewDto> SubModules { get; set; }
		public List<CodelabSummaryDto> Codelabs { get; set; }
		public StatusDto Status { get; set; }

		public bool Edit { get; set; } = false;
	}
}
