using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;
using System.Net.Http.Json;
using LMSBase.Models.Dtos.Request;

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

		public async Task EditModuleName(int moduleId, LearningModuleOverviewDto learningModuleOverviewDto)
		{
			var apiResponse = await _httpClient.PutAsJsonAsync($"/api/modules/{moduleId}",learningModuleOverviewDto);
			apiResponse.EnsureSuccessStatusCode();
		}

		public async Task CreateModule(CreateLearningModuleDto createLearningModuleDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/modules", createLearningModuleDto);
			apiResponse.EnsureSuccessStatusCode();
		}

		
	}
}
