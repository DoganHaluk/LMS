using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;
using LMSBase.Models.Utilities;
using System.Net;

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

		public async Task<List<InputError>> CreateCodelab(CreateCodelabDto createCodelabDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/codelabs", createCodelabDto);
			if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				return errors;
			}
			return null;
		}

		public async Task<List<InputError>> EditCodelab(int codelabId,EditCodelabDto editCodelabDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync($"/api/codelabs/{codelabId}", editCodelabDto);
			if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				return errors;
			}
			return null;
		}

		public async Task DeleteCodelab(int id)
		{
			var apiResponse = await _httpClient.DeleteAsync($"/api/codelabs/{id}");
		}
	}
}
