﻿using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos
{
	public class SchoolClassOverviewDto
	{
		public int SchoolClassId { get; set; }
		public string SchoolClassName { get; set; }

		public List<StudentForOverviewDto> Students { get; set; }

		public List<CoachFromCoachSchoolClassDto> CoachSchoolClasses { get; set; }
	}
}
