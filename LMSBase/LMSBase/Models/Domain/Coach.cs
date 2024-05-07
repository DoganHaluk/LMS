using System.Security.Claims;

namespace LMSBase.Models.Domain
{
	public class Coach : User
	{
		public List<SchoolClass> SchoolClasses { get; set; }
	}
}
