using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class CourseDto
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }

		public bool Selected { get; set; } = false;
	}
}
