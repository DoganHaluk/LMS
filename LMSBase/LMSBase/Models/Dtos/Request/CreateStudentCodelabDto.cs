using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
	public class CreateStudentCodelabDto
	{
		public int UserId { get; set; }

		public int CodelabId { get; set; }

		public string Comment { get; set; } = "";

		public int StatusId { get; set; } = 2;		
	}
}
