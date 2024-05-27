using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;
using System.Net.Http.Json;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Utilities;
using System.Net;

namespace LMSBlazor.Services
{
	public class LearningModuleService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public LearningModuleService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}

		public async Task<List<InputError>> EditModuleName(int moduleId, LearningModuleOverviewDto learningModuleOverviewDto)
		{
			var apiResponse = await _httpClient.PutAsJsonAsync($"/api/modules/{moduleId}",learningModuleOverviewDto);
			if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				return errors;
			}
			return null;
		}

		public async Task<List<InputError>> CreateModule(CreateLearningModuleDto createLearningModuleDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/modules", createLearningModuleDto);
			if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				return errors;
			}
			return null;
		}

		public async Task DeleteModule(int id)
		{
			var apiResponde = await _httpClient.DeleteAsync($"/api/modules/{id}");
			apiResponde.EnsureSuccessStatusCode();
		}

	}
}
