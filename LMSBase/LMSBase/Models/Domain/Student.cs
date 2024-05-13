using System.Security.Claims;
using System.Text.RegularExpressions;

namespace LMSBase.Models.Domain
{
	public class Student : User
	{
		public int? SchoolClassId { get; set; }
		public SchoolClass SchoolClass { get; set; }
		public List<StudentCodelab> StudentCodelabs { get; set; }
	}
}
