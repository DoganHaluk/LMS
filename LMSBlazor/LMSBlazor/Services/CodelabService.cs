using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;

namespace LMSBlazor.Services
{
	public class CodelabService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public CodelabService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}

		public async Task CreateCodelab(CreateCodelabDto createCodelabDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/codelabs", createCodelabDto);
			apiResponse.EnsureSuccessStatusCode();
		}

		public async Task EditCodelab(int codelabId,EditCodelabDto editCodelabDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync($"/api/codelabs/{codelabId}", editCodelabDto);
			apiResponse.EnsureSuccessStatusCode();
		}

		public async Task DeleteCodelab(int id)
		{
			var apiResponse = await _httpClient.DeleteAsync($"/api/codelabs/{id}");
		}
	}
}
