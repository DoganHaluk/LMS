using System.Net.Http.Headers;

namespace LMSBlazor.Services
{
	public class TokenService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationService _authenticationService;

		public TokenService(HttpClient httpClient, AuthenticationService authenticationService)
		{
			_httpClient = httpClient;
			_authenticationService = authenticationService;
		}

		public async Task AddTokenAsync()
		{
			var user = await _authenticationService.GetUserAsync();
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{user.Token}");
		}
	}
}
