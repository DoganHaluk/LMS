using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;
using LMSBase.Models.Dtos.Response;
using System.Net;

namespace LMSBlazor.Services
{
	public class AuthenticationService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;
		private readonly StateContainer _stateContainer;

		public AuthenticationService(HttpClient httpClient,StateContainer stateContainer)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
			_stateContainer = stateContainer;
		}



		public async Task<bool> UserLoginAsync(LoginDto login)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/authentication", login);
			if (apiResponse.StatusCode == HttpStatusCode.OK)
			{
				CurrentUser user = JsonSerializer.Deserialize<CurrentUser>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				await _stateContainer.SetUserAsync(user);
				return true;
			}
			return false;			
		}

		public async Task UserLogoutAsync()
		{
			await _stateContainer.SetUserAsync(null);
		}
	}
}
