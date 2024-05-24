using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class CodelabSummaryDto
	{
		public int CodelabId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public bool Edit { get; set; } = false;
	}
}
