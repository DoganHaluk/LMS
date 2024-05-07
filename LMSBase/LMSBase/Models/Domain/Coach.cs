using System.Security.Claims;

namespace LMSBase.Models.Domain
{
	public class Coach : User
	{
		public List<CoachSchoolClass> CoachSchoolClasses { get; set; }
	}
}
