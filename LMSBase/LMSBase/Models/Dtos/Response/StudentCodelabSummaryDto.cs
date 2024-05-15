using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class StudentCodelabSummaryDto
	{
		public int StudentCodelabId { get; set; }

		public string Comment { get; set; }

		public StatusDto Status { get; set; }

	}
}
