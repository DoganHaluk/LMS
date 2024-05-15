using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class LearningModuleDto
	{
		public int LearningModuleId { get; set; }
		public string ModuleName { get; set; }
		public List<LearningModule> SubModules { get; set; }
		public LearningModule Parent { get; set; }
		public List<Codelab> Codelabs { get; set; }
		public StatusDto Status { get; set; }
	}
}
