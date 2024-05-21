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
		private readonly LocalStorageService _storageService;

		public AuthenticationService(HttpClient httpClient,LocalStorageService localStorageService)
		{
			_httpClient = httpClient;
			_storageService = localStorageService;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}



		public async Task<bool> UserLoginAsync(LoginDto login)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/authentication", login);
			if (apiResponse.StatusCode == HttpStatusCode.OK)
			{
				User user = JsonSerializer.Deserialize<User>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				_storageService.SetItem("currentUser", user);
				return true;
			}
			return false;			
		}

		public async Task<User> GetUserAsync()
		{
			return await _storageService.GetItem<User>("currentUser");
		}


	}
}
