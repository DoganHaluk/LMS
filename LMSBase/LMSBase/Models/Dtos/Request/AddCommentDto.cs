using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
	public class AddCommentDto
	{
		public int StudentCodelabId { get; set; }

		public string Comment { get; set; }
	}
}
