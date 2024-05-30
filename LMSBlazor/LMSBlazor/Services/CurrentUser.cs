namespace LMSBlazor.Services
{
	public class CurrentUser
	{
		public int? UserId { get; set; }

		public string? UserName { get; set; }
		
		public string? Token { get; set; }

		public string? Role { get; set; }
	}
}
