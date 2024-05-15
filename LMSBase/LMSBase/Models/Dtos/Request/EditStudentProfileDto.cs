using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
    public class EditStudentProfileDto
    {
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }

		public int SchoolClassId { get; set; }
	}
}
