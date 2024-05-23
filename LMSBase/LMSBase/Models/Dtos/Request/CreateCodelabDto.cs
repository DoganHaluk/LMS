using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
	public class CreateCodelabDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int LearningModuleId { get; set; }

		public bool Edit {  get; set; }=false;
	}
}
