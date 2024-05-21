using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;

namespace LMSBlazor.Services
{
	public class CoachService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public CoachService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}

		public async Task<CoachSummaryDto> GetCoachProfileAsync(int id)
		{
			CoachSummaryDto coach = new CoachSummaryDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/coach/{id}");
			coach = JsonSerializer.Deserialize<CoachSummaryDto>(apiResponse, _serializerOptions);
			return coach;
		}

	}
}
