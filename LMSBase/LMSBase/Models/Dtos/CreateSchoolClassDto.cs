﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos
{
	public class CreateSchoolClassDto
	{
		public int SchoolClassId {  get; set; } 
		public string SchoolClassName { get; set; }

		public int CoachId { get; set; }
	}
}
