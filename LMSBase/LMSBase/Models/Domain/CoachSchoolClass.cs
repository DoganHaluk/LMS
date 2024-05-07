using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Domain
{
	public class CoachSchoolClass
	{
		public int CoachSchoolClassId { get; set; }

		public int CoachId { get; set; }
		public Coach Coach { get; set; }

		public int SchoolClassId { get; set; }

		public SchoolClass SchoolClass { get; set; }
	}
}
