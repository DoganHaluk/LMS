using System.Net.Http.Headers;

namespace LMSBlazor.Services
{
	public class TokenService
	{
		private readonly HttpClient _httpClient;
		private readonly StateContainer _stateContainer;

		public TokenService(HttpClient httpClient, StateContainer stateContainer)
		{
			_httpClient = httpClient;
			_stateContainer = stateContainer;
		}

		public async Task AddTokenAsync()
		{
			var user = await _stateContainer.GetUserAsync();
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{user.Token}");
		}
	}
}
