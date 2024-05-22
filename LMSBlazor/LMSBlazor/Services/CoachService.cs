using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;
using System.Net.Http.Headers;

namespace LMSBlazor.Services
{
	public class CoachService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;
		private readonly TokenService _tokenService;

		private CurrentUser user {  get; set; }

		public CoachService(HttpClient httpClient, TokenService tokenService)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
			_tokenService = tokenService;
		}

		public async Task<CoachSummaryDto> GetCoachProfileAsync(int id)
		{
			await _tokenService.AddTokenAsync();
			CoachSummaryDto coach = new CoachSummaryDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/coach/{id}");
			coach = JsonSerializer.Deserialize<CoachSummaryDto>(apiResponse, _serializerOptions);
			return coach;
		}

	}
}
