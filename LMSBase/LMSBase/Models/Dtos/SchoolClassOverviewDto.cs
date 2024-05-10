using LMSBase.Models.Domain;
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

		public List<string> StudentsNames { get; set; } = new List<string>();

		public List<string> CoachesNames { get; set; } = new List<string>();
	}
}
