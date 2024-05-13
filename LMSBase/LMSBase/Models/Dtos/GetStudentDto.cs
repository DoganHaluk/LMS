﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos
{
	public class GetStudentDto
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }

		public SchoolClassForListDto SchoolClass { get; set; }
	}
}
