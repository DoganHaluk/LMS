using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
	public class EditStudentPasswordDto
	{
		public int UserId { get; set; }

		public string Password { get; set; }

		public string RepeatPassword { get; set; }
	}
}
