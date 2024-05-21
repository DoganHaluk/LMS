using LMSBase.Models.Dtos.Request;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class Login
	{

		private LoginDto UserLogin {  get; set; } = new LoginDto();

		private string ErrorMessage { get; set; }


		public async Task HandleLogin()
		{
			var success = await _authenticationService.UserLoginAsync(UserLogin);
			if (success == true) 
			{
				var user = await _localStorageService.GetItem<User>("currentUser");
				if (user.Role == "Student")
				{
                    _navigate.NavigateTo($"/studentprofile?UserId={user.UserId}");
                }				
				else if (user.Role == "Coach")
				{
                    _navigate.NavigateTo($"/coachprofile?UserId={user.UserId}");
                }
			}
			else
			{
				ErrorMessage = "Invalid Login";
			}
		}
	}
}