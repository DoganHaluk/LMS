using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Domain
{
	public class Progression
	{
		public string StudentName { get; set; }

		public int TotalCodelabs { get; set; }

		public int FinishedCodelabs { get; set; }
	}
}
