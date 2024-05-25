using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
	public class UpdateStatusCodelabDto
	{
		public int StudentCodelabId { get; set; }
		public int? StatusId { get; set; }

		public string StatusName { get; set; }
	}
}
