using System.Security.Claims;

namespace LMSBase.Models.Domain
{
	public class User
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public List<Claim> Claims { get; set; } = new List<Claim>();
	}
}
